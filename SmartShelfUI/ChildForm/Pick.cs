using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class Pick : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        public Pick()
        {
            InitializeComponent();
        }

        public delegate void FormHandle();
        public delegate void FormHandle2(int partid);
        public event FormHandle nextForm_menu;
        public event FormHandle nextForm_exit;

        //public event FormHandle nextForm_dispick_plan;
        public event FormHandle2 nextForm_dispick_plan_partnum;
        public event FormHandle nextForm_dispick_unplan;

        private void btnMenu_Click(object sender, EventArgs e)
        {
            nextForm_menu();
        }

        private void Pick_Load(object sender, EventArgs e)
        {
            GetOrderList();
        }

        /// <summary>
        /// 获取中间表主表
        /// </summary>
        public void GetOrderList()
        {
            panel_order.Controls.Clear();
            nowPartId = "";
            string sql = "select * from temp_planorderlist where OrderReadyState = 1 or OrderReadyState = -1 order by PlanWorkTime desc";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btnOrder = new Button();
                    btnOrder.BackgroundImage = global::SmartShelfUI.Properties.Resources.按钮1;
                    btnOrder.BackgroundImageLayout = ImageLayout.Stretch;
                    btnOrder.FlatAppearance.BorderSize = 0;
                    btnOrder.FlatStyle = FlatStyle.Flat;
                    btnOrder.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                    btnOrder.ForeColor = Color.White;
                    btnOrder.Location = new Point(3, 3 + 55 * i);
                    btnOrder.Size = new Size(540, 55);
                    string partState = dt.Rows[i]["OrderReadyState"].ToString() == "1" ? "备刀中" : dt.Rows[i]["OrderReadyState"].ToString() == "-1" ? "异常" : dt.Rows[i]["OrderReadyState"].ToString();
                    btnOrder.Text = dt.Rows[i]["PartNum"].ToString() + "   "
                        + dt.Rows[i]["PartName"].ToString() + "   "
                        + dt.Rows[i]["MaterialTexture"].ToString() + "   "
                        + Convert.ToDateTime(dt.Rows[i]["PlanWorkTime"]).ToString("MM-dd HH:mm") + "   "
                        + dt.Rows[i]["MachineLathe"].ToString() + "   "
                        + dt.Rows[i]["WorkProcedure"].ToString() + "   "
                        + partState;
                    //btnOrder.Text = "M123-0909      金属外壳     铝合金     2019-05-10 10:10    3号机台     备料中";
                    //btnOrder.Tag = dt.Rows[i]["PartNum"].ToString();
                    btnOrder.Tag = dt.Rows[i]["Id"].ToString() + "|" + dt.Rows[i]["PartNum"].ToString();
                    btnOrder.UseVisualStyleBackColor = true;
                    //btnOrder.Click += new System.EventHandler(btnOrder_Click);
                    btnOrder.MouseDown += new MouseEventHandler(btnOrder_MouseDown);
                    panel_order.Controls.Add(btnOrder);
                }
            }
        }

        string nowPartNum = "";
        string nowPartId = "";
        /// <summary>
        /// 点击零件订单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                //左键点击事件
                panel_shelf.Controls.Clear();
                Button btn = sender as Button;
                nowPartId = btn.Tag.ToString().Split('|')[0];
                nowPartNum = btn.Tag.ToString().Split('|')[1];
                GetCamList();
            }
            else if (Mouse_e.Button == MouseButtons.Right)
            {
                //右键点击事件
                if (MessageBox.Show("确认推迟锁刀吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ChildForm.ComfirmDelayTime frmDelay = new ComfirmDelayTime();
                    Button btn = sender as Button;
                    string PartNum = btn.Tag.ToString();
                    List<DTcms.Model.temp_planorderlist> lst = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + PartNum + "'");
                    frmDelay.PlanID = lst[0].Id;
                    if (frmDelay.ShowDialog() == DialogResult.OK)
                    {
                        GetOrderList();
                        string sql = "select c.Id,c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' WHEN -2 THEN '已取消' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where 1=2";
                        DataTable dtnull = DbHelperMySql.Query(sql).Tables[0];
                        dgvCamList.DataSource = dtnull;
                        panel_shelf.Controls.Clear();
                    }
                }
            }
        }
        /// <summary>
        /// 开门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            Button btnOpenDoor = sender as Button;
            string cabinetNo = btnOpenDoor.Tag.ToString().Split('|')[0];
            string shelfNo = btnOpenDoor.Tag.ToString().Split('|')[1];
            string shelfId = btnOpenDoor.Tag.ToString().Split('|')[2];
            string PartNo = btnOpenDoor.Tag.ToString().Split('|')[3];
            string PartId = btnOpenDoor.Tag.ToString().Split('|')[4];
            //开门TCPIP
            string IP = "";
            string Port = "";
            DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(shelfId));
            DTcms.Model.sy_cabinet cabinet = new DTcms.Model.sy_cabinet();
            if (shelf != null)
            {
                cabinet = new DTcms.BLL.sy_cabinet().GetModelList("CabinetNo = '" + shelf.FK_CabinetNo + "'")[0];
                IP = cabinet.IP;
                Port = cabinet.Port;
            }
            if (connect(IP, Port))
            {
                byte[] rec_byte = null;
                byte[] code_byte = new byte[6];
                code_byte[0] = 0xFF;
                code_byte[1] = (byte)Convert.ToInt32(cabinet.CardAddr, 16);
                code_byte[2] = (byte)Convert.ToInt32(shelf.BoxAddr, 16);
                code_byte[3] = 0x01;
                code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                code_byte[5] = 0xFE;
                rec_byte = sendtcpip(code_byte, IP, Port);
                if (VerifyReceive(rec_byte))
                {
                    if (rec_byte[3] == 0x01)//门正常打开
                    {
                        string sql = "select w.X,w.Y from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.FK_Id = '" + PartId + "' and s.ID = " + shelfId;
                        DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                        ChildForm.CellsLocation frmCellsLocation = new CellsLocation();
                        frmCellsLocation.ShelfID = int.Parse(shelfId);
                        frmCellsLocation.PartNum = PartNo;
                        frmCellsLocation.PartId = PartId;
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                frmCellsLocation.lstSelected.Add(dt.Rows[i]["X"].ToString() + "-" + dt.Rows[i]["Y"].ToString());
                            }
                        }
                        frmCellsLocation.ShowDialog();
                        sql = "select c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.FK_Id = " + PartId + "";
                        sql += " order by s.FK_CabinetNo,s.BoxNo,c.ToolReadyState";
                        dt = DbHelperMySql.Query(sql).Tables[0];
                        dgvCamList.DataSource = dt;
                        //循环CAM表状态，是否更新任务令表状态
                        List<DTcms.Model.temp_camlist> camlist = new DTcms.BLL.temp_camlist().GetModelList("FK_Id = " + PartId + "");
                        bool isDone = true;
                        foreach (DTcms.Model.temp_camlist item in camlist)
                        {
                            if (item.ToolReadyState == 2 || item.ToolReadyState == -2)//已领刀 或 cancel
                            {
                                continue;
                            }
                            else if (item.ToolReadyState == -1)//有一把异常，主表状态就为异常
                            {
                                isDone = false;
                                break;
                            }
                            else if (item.ToolReadyState == 1)//有一把未领，主表状态就为未领
                            {
                                isDone = false;
                                break;
                            }
                            else if (item.ToolReadyState == 0)
                            {
                                isDone = false;
                                break;
                            }
                        }
                        if (isDone)
                        {
                            DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("Id = " + PartId + "")[0];
                            planorder.OrderReadyState = 2;
                            new DTcms.BLL.temp_planorderlist().Update(planorder);
                            this.nowPartNum = this.nowPartId = "";
                        }
                        GetOrderList();
                        GetCamList();
                    }
                    else if (rec_byte[3] == 0x00)//门开着，不能打开
                    {
                        MessageBox.Show("检测到抽屉门已打开，请确认是否有他人正在操作，否则请关闭抽屉门后重新操作，谢谢！");
                    }
                    else
                    {
                        MessageBox.Show("开门指令执行失败！请联系管理员检查硬件！");
                    }
                }
                else
                {
                    MessageBox.Show("网络通讯返回错误！");
                }
            }
            else
            {
                MessageBox.Show("网络通信失败！");
            }
        }

        public void GetCamList()
        {
            lstShelf.Clear();
            if (!string.IsNullOrEmpty(nowPartId))
            {
                string sql = "select c.Id,c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' WHEN -2 THEN '已取消' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.FK_Id = " + nowPartId + " and ToolReadyState <> -1";
                sql += " order by s.FK_CabinetNo,s.BoxNo,c.ToolReadyState";
                DataSet ds1 = DbHelperMySql.Query(sql);
                sql = "select c.Id,c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' WHEN -2 THEN '已取消' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.FK_Id = " + nowPartId + " and ToolReadyState = -1";
                sql += " order by s.FK_CabinetNo,s.BoxNo,c.ToolReadyState";
                DataSet ds2 = DbHelperMySql.Query(sql);

                ds1.Merge(ds2);
                //DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                DataTable dt = ds1.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCamList.DataSource = dt;

                    sql = "select DISTINCT s.FK_CabinetNo,s.BoxNo,s.ID as shelfid from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.FK_Id = " + nowPartId + " and c.ToolReadyState = 1 ORDER BY CONVERT(c.toolnum, signed)";
                    //order by s.FK_CabinetNo,BoxNo
                    DataTable dtShelf = DbHelperMySql.Query(sql).Tables[0];
                    if (dtShelf != null && dtShelf.Rows.Count > 0 && dtShelf.Rows[0][0].ToString() != "" && dtShelf.Rows[0][2].ToString() != "")
                    {
                        for (int i = 0; i < dtShelf.Rows.Count; i++)
                        {
                            Button btnShelf = new Button();
                            //btnShelf.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
                            //btnShelf.BackgroundImageLayout = ImageLayout.Stretch;
                            btnShelf.BackColor = Color.Silver;
                            btnShelf.FlatAppearance.BorderSize = 0;
                            btnShelf.FlatStyle = FlatStyle.Flat;
                            btnShelf.Font = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            btnShelf.ForeColor = Color.White;
                            btnShelf.Location = new Point(8, 40 * i + 10);
                            btnShelf.Size = new Size(190, 35);
                            btnShelf.Text = dtShelf.Rows[i]["FK_CabinetNo"].ToString() + "号柜" + dtShelf.Rows[i]["BoxNo"].ToString() + "号抽屉";
                            btnShelf.Tag = dtShelf.Rows[i]["FK_CabinetNo"].ToString() + "|" + dtShelf.Rows[i]["BoxNo"].ToString() + "|" + dtShelf.Rows[i]["shelfid"].ToString() + "|" + nowPartNum + "|" + nowPartId;
                            btnShelf.UseVisualStyleBackColor = true;
                            //btnShelf.Click += btnOpenDoor_Click;
                            panel_shelf.Controls.Add(btnShelf);

                            lstShelf.Add(dtShelf.Rows[i]["shelfid"].ToString());
                        }
                    }
                }
            }
            else
            {
                string sql = "select c.Id,c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' WHEN -2 THEN '已取消' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where 1=2";
                DataTable dtnull = DbHelperMySql.Query(sql).Tables[0];
                dgvCamList.DataSource = dtnull;
                panel_shelf.Controls.Clear();
            }
        }
        /// <summary>
        /// 领用完成，退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            nextForm_exit();
        }

        private IPEndPoint serverFullAddr;
        private Socket sock;
        private bool connect(string IP, string Port)
        {
            IPAddress serverIP;
            int port;
            serverIP = IPAddress.Parse(IP);
            port = int.Parse(Port);
            try
            {
                serverFullAddr = new IPEndPoint(serverIP, port);//设置IP，端口  
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //指定本地主机地址和端口号  
                sock.Connect(serverFullAddr);
                sock.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private byte[] sendtcpip(byte[] byteCode, string IP, string Port)
        {
            try
            {
                IPAddress serverIP;
                int port;
                serverIP = IPAddress.Parse(IP);
                port = int.Parse(Port);
                serverFullAddr = new IPEndPoint(serverIP, port);//设置IP，端口  
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //指定本地主机地址和端口号  
                sock.Connect(serverFullAddr);
                byte[] message = new byte[1024 * 64];
                int bytes = 0;
                //发送数据
                sock.Send(byteCode);
                bytes = sock.Receive(message);//接收数据 
                byte[] returnreceive = new byte[bytes];
                Array.Copy(message, 0, returnreceive, 0, bytes);
                sock.Close();
                return returnreceive;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sock.Close();
            }
        }
        private bool VerifyReceive(byte[] receive)
        {
            if (receive.Length != 6)
            {
                return false;
            }
            if (receive[0] != 0xFE)
            {
                return false;
            }
            if (receive[5] != 0xFF)
            {
                return false;
            }
            if (receive[4] != Convert.ToByte(receive[1] ^ receive[2] ^ receive[3]))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 计划零星领用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisPick1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nowPartId))
            {
                nextForm_dispick_plan_partnum(int.Parse(nowPartId));
            }
            else
            {
                MessageBox.Show("请选择计划令！");
            }

        }
        /// <summary>
        /// 非计划另行领用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisPick2_Click(object sender, EventArgs e)
        {
            nextForm_dispick_unplan();
        }

        /// <summary>
        /// 取消CAM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelCAM_Click(object sender, EventArgs e)
        {
            if (dgvCamList.SelectedRows != null && dgvCamList.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确认取消该CAM？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string camid = dgvCamList.SelectedRows[0].Cells[0].Value.ToString();
                    DTcms.Model.temp_camlist cam = new DTcms.BLL.temp_camlist().GetModel(int.Parse(camid));
                    cam.ToolReadyState = -2;
                    new DTcms.BLL.temp_camlist().Update(cam);
                    if (!string.IsNullOrEmpty(cam.ToolBarCode))
                    {
                        DTcms.Model.w_barcode tool = new DTcms.BLL.w_barcode().GetModel(cam.ToolBarCode);
                        if (tool.State == 4)
                        {
                            tool.State = 1;
                            new DTcms.BLL.w_barcode().Update(tool);
                        }
                    }

                    //循环CAM表状态，是否更新任务令表状态
                    List<DTcms.Model.temp_camlist> camlist = new DTcms.BLL.temp_camlist().GetModelList("FK_Id = " + cam.FK_Id + "");
                    bool isDone = true;
                    foreach (DTcms.Model.temp_camlist item in camlist)
                    {
                        if (item.ToolReadyState == 2 || item.ToolReadyState == -2)//已领刀 或 cancel
                        {
                            continue;
                        }
                        else if (item.ToolReadyState == -1)//有一把异常，主表状态就为异常
                        {
                            //DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0];
                            DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModel(cam.FK_Id);
                            planorder.OrderReadyState = -1;
                            new DTcms.BLL.temp_planorderlist().Update(planorder);
                            isDone = false;
                            break;
                        }
                        else if (item.ToolReadyState == 1)//有一把未领，主表状态就为未领
                        {
                            //DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0];
                            DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModel(cam.FK_Id);
                            planorder.OrderReadyState = 1;
                            new DTcms.BLL.temp_planorderlist().Update(planorder);
                            isDone = false;
                            break;
                        }
                        else if (item.ToolReadyState == 0)
                        {
                            isDone = false;
                            break;
                        }
                    }
                    if (isDone)
                    {
                        //DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0];
                        DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModel(cam.FK_Id);
                        planorder.OrderReadyState = 2;
                        new DTcms.BLL.temp_planorderlist().Update(planorder);
                        this.nowPartNum = this.nowPartId = "";
                        GetOrderList();
                        GetCamList();
                    }
                    else
                    {
                        GetCamList();
                    }

                }
            }
            else
            {
                MessageBox.Show("请选择CAM！");
            }

        }

        private void btnRefreshOrder_Click(object sender, EventArgs e)
        {
            GetOrderList();
            string sql = "select c.Id,c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' WHEN -2 THEN '已取消' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where 1=2";
            DataTable dtnull = DbHelperMySql.Query(sql).Tables[0];
            dgvCamList.DataSource = dtnull;
            panel_shelf.Controls.Clear();
        }

        private void dgvCamList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvCamList.Rows.Count; i++)
                {
                    if (dgvCamList.Rows[i].Cells[7].Value.ToString() == "已取料")
                    {
                        this.dgvCamList.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                    else if (dgvCamList.Rows[i].Cells[7].Value.ToString() == "异常")
                    {
                        this.dgvCamList.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Writelog(ex.ToString(), "改变cam颜色");
            }

        }

        public delegate void SendHandle(List<string> lst_shelf_id, string Part_ID);
        public event SendHandle sendShelfCode;
        List<string> lstShelf = new List<string>();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nowPartNum) || string.IsNullOrEmpty(nowPartId))
            {
                MessageBox.Show("请选择零件计划单！");
                return;
            }
            GetCamList();
            if (lstShelf != null && lstShelf.Count > 0)
            {
                sendShelfCode(lstShelf, nowPartId);
            }
            else
            {
                MessageBox.Show("没有符合要求的抽屉！");
                return;
            }
        }
    }
}
