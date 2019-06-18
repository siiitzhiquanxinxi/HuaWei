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
        public Pick()
        {
            InitializeComponent();
        }

        public delegate void FormHandle();
        public event FormHandle nextForm_menu;
        public event FormHandle nextForm_exit;

        public event FormHandle nextForm_dispick_plan;
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
        private void GetOrderList()
        {
            panel_order.Controls.Clear();
            string sql = "select * from temp_planorderlist where OrderReadyState = 1 order by PlanWorkTime asc";
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
                    btnOrder.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                    btnOrder.ForeColor = Color.White;
                    btnOrder.Location = new Point(3, 3 + 55 * i);
                    btnOrder.Size = new Size(540, 55);
                    btnOrder.Text = dt.Rows[i]["PartNum"].ToString() + "    "
                        + dt.Rows[i]["PartName"].ToString() + "    "
                        + dt.Rows[i]["MaterialTexture"].ToString() + "    "
                        + Convert.ToDateTime(dt.Rows[i]["PlanWorkTime"]).ToString("yyyy-MM-dd HH:mm") + "    "
                        + dt.Rows[i]["MachineLathe"].ToString() + "    "
                        + dt.Rows[i]["OrderReadyState"].ToString();
                    //btnOrder.Text = "M123-0909      金属外壳     铝合金     2019-05-10 10:10    3号机台     备料中";
                    btnOrder.Tag = dt.Rows[i]["PartNum"].ToString();
                    btnOrder.UseVisualStyleBackColor = true;
                    //btnOrder.Click += new System.EventHandler(btnOrder_Click);
                    btnOrder.MouseDown += new MouseEventHandler(btnOrder_MouseDown);
                    panel_order.Controls.Add(btnOrder);
                }
            }
        }

        /// <summary>
        /// 点击订单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                //左键点击事件
                panel_shelf.Controls.Clear();
                Button btn = sender as Button;
                string PartNum = btn.Tag.ToString();
                string sql = "select c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNum + "'";
                sql += " order by s.FK_CabinetNo,s.BoxNo,c.ToolReadyState";
                DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCamList.DataSource = dt;

                    sql = "select DISTINCT s.FK_CabinetNo,s.BoxNo,s.ID as shelfid from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNum + "'";
                    DataTable dtShelf = DbHelperMySql.Query(sql).Tables[0];
                    if (dtShelf != null && dtShelf.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtShelf.Rows.Count; i++)
                        {
                            Button btnShelf = new Button();
                            btnShelf.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
                            btnShelf.BackgroundImageLayout = ImageLayout.Stretch;
                            btnShelf.FlatAppearance.BorderSize = 0;
                            btnShelf.FlatStyle = FlatStyle.Flat;
                            btnShelf.Font = new Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            btnShelf.ForeColor = Color.White;
                            btnShelf.Location = new Point(8, 70 * i + 8);
                            btnShelf.Size = new Size(190, 70);
                            btnShelf.Text = "打开" + dtShelf.Rows[i]["FK_CabinetNo"].ToString() + "号柜" + dtShelf.Rows[i]["BoxNo"].ToString() + "号抽屉";
                            btnShelf.Tag = dtShelf.Rows[i]["FK_CabinetNo"].ToString() + "|" + dtShelf.Rows[i]["BoxNo"].ToString() + "|" + dtShelf.Rows[i]["shelfid"].ToString() + "|" + PartNum;
                            btnShelf.UseVisualStyleBackColor = true;
                            btnShelf.Click += btnOpenDoor_Click;
                            panel_shelf.Controls.Add(btnShelf);
                        }
                    }
                }
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
                    }
                }
            }

        }


        /// <summary>
        /// 点击订单列表
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
                string PartNum = btn.Tag.ToString();
                string sql = "select c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNum + "'";
                sql += " order by s.FK_CabinetNo,s.BoxNo,c.ToolReadyState";
                DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCamList.DataSource = dt;

                    sql = "select DISTINCT s.FK_CabinetNo,s.BoxNo,s.ID as shelfid from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNum + "'";
                    DataTable dtShelf = DbHelperMySql.Query(sql).Tables[0];
                    if (dtShelf != null && dtShelf.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtShelf.Rows.Count; i++)
                        {
                            Button btnShelf = new Button();
                            btnShelf.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
                            btnShelf.BackgroundImageLayout = ImageLayout.Stretch;
                            btnShelf.FlatAppearance.BorderSize = 0;
                            btnShelf.FlatStyle = FlatStyle.Flat;
                            btnShelf.Font = new Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            btnShelf.ForeColor = Color.White;
                            btnShelf.Location = new Point(8, 70 * i + 8);
                            btnShelf.Size = new Size(190, 70);
                            btnShelf.Text = "打开" + dtShelf.Rows[i]["FK_CabinetNo"].ToString() + "号柜" + dtShelf.Rows[i]["BoxNo"].ToString() + "号抽屉";
                            btnShelf.Tag = dtShelf.Rows[i]["FK_CabinetNo"].ToString() + "|" + dtShelf.Rows[i]["BoxNo"].ToString() + "|" + dtShelf.Rows[i]["shelfid"].ToString() + "|" + PartNum;
                            btnShelf.UseVisualStyleBackColor = true;
                            btnShelf.Click += btnOpenDoor_Click;
                            panel_shelf.Controls.Add(btnShelf);
                        }
                    }
                }
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
                    }
                }
            }

        }

        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            Button btnOpenDoor = sender as Button;
            string cabinetNo = btnOpenDoor.Tag.ToString().Split('|')[0];
            string shelfNo = btnOpenDoor.Tag.ToString().Split('|')[1];
            string shelfId = btnOpenDoor.Tag.ToString().Split('|')[2];
            string PartNo = btnOpenDoor.Tag.ToString().Split('|')[3];
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
                        string sql = "select w.X,w.Y from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNo + "' and s.ID = " + shelfId;
                        DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                        ChildForm.CellsLocation frmCellsLocation = new CellsLocation();
                        frmCellsLocation.ShelfID = int.Parse(shelfId);
                        frmCellsLocation.PartNum = PartNo;
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                frmCellsLocation.lstSelected.Add(dt.Rows[i]["X"].ToString() + "-" + dt.Rows[i]["Y"].ToString());
                            }
                        }
                        frmCellsLocation.ShowDialog();
                        sql = "select c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo,(CASE c.ToolReadyState  WHEN 0 THEN '待备料' WHEN 1 THEN '待取料' WHEN 2 THEN '已取料' ELSE '异常' END) as ToolReadyState from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNo + "'";
                        sql += " order by s.FK_CabinetNo,s.BoxNo,c.ToolReadyState";
                        dt = DbHelperMySql.Query(sql).Tables[0];
                        dgvCamList.DataSource = dt;
                        //循环CAM表状态，是否更新任务令表状态
                        List<DTcms.Model.temp_camlist> camlist = new DTcms.BLL.temp_camlist().GetModelList("PartNum = '" + PartNo + "'");
                        bool isDone = true;
                        foreach (DTcms.Model.temp_camlist item in camlist)
                        {
                            if (item.ToolReadyState == 2 || item.ToolReadyState == -2)//已领刀 或 cancel
                            {
                                continue;
                            }
                            else if (item.ToolReadyState == -1)//有一把异常，主表状态就为异常
                            {
                                DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + PartNo + "'")[0];
                                planorder.OrderReadyState = -1;
                                new DTcms.BLL.temp_planorderlist().Update(planorder);
                                isDone = false;
                                break;
                            }
                            else if (item.ToolReadyState == 1)//有一把未领，主表状态就为未领
                            {
                                DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + PartNo + "'")[0];
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
                            DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + PartNo + "'")[0];
                            planorder.OrderReadyState = 2;
                            new DTcms.BLL.temp_planorderlist().Update(planorder);
                        }
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
            nextForm_dispick_plan();
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

                    //循环CAM表状态，是否更新任务令表状态
                    List<DTcms.Model.temp_camlist> camlist = new DTcms.BLL.temp_camlist().GetModelList("PartNum = '" + cam.PartNum + "'");
                    bool isDone = true;
                    foreach (DTcms.Model.temp_camlist item in camlist)
                    {
                        if (item.ToolReadyState == 2 || item.ToolReadyState == -2)//已领刀 或 cancel
                        {
                            continue;
                        }
                        else if (item.ToolReadyState == -1)//有一把异常，主表状态就为异常
                        {
                            DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0];
                            planorder.OrderReadyState = -1;
                            new DTcms.BLL.temp_planorderlist().Update(planorder);
                            isDone = false;
                            break;
                        }
                        else if (item.ToolReadyState == 1)//有一把未领，主表状态就为未领
                        {
                            DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0];
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
                        DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0];
                        planorder.OrderReadyState = 2;
                        new DTcms.BLL.temp_planorderlist().Update(planorder);
                    }
                    GetOrderList();
                }
            }
            else
            {
                MessageBox.Show("请选择CAM！");
            }

        }
    }
}
