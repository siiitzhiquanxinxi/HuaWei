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
    public partial class DisPick_Plan : Form
    {
        public DisPick_Plan()
        {
            InitializeComponent();
        }
        public DisPick_Plan(string partNum)
        {
            InitializeComponent();
            txtPartNum.Text = partNum;
        }

        private void DisPick_Plan_Load(object sender, EventArgs e)
        {
            GetApproveList();
        }

        private void GetApproveList()
        {
            string sql = "select ApproveNum,CreateDate,CreateByName,ApplyToolName,ApplyPartNum,(CASE ApproveState WHEN 0 THEN '待审核' ELSE '已审核' END) as state,FK_CabinetNo,BoxNo from w_approvelist LEFT JOIN w_barcode on w_barcode.BarCode = w_approvelist.ApproveNewToolBarCode LEFT JOIN sy_shelf on sy_shelf.ID = w_barcode.FK_ShelfID where (ApproveState = 0 or ApproveState = 1) and IsPlanApprove = 1 order by ApproveState desc,CreateDate desc";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            dgv_ApproveList.DataSource = dt;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgv_ApproveList.SelectedRows != null && dgv_ApproveList.SelectedRows.Count > 0)
            {
                string ApproveNum = dgv_ApproveList.SelectedRows[0].Cells[0].Value.ToString();
                DTcms.Model.w_approvelist approve = new DTcms.BLL.w_approvelist().GetModel(ApproveNum);
                if (approve != null)
                {
                    if (approve.ApproveState == 0)
                    {
                        MessageBox.Show("尚未审核通过！");
                    }
                    else if (approve.ApproveState == 1)
                    {
                        DTcms.Model.w_barcode tool = new DTcms.BLL.w_barcode().GetModel(approve.ApproveNewToolBarCode);
                        if (tool != null)
                        {
                            DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModel(Convert.ToInt32(tool.FK_ShelfID));
                            DTcms.Model.sy_cabinet cabinet = new DTcms.BLL.sy_cabinet().GetModel(shelf.FK_CabinetNo);
                            CellsLocationForGeneral frmCells = new CellsLocationForGeneral(true);
                            frmCells.tool = tool;
                            frmCells.cabinet = cabinet;
                            frmCells.shelf = shelf;
                            string IP = cabinet.IP;
                            string Port = cabinet.Port;
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
                                        if (frmCells.ShowDialog() == DialogResult.OK)
                                        {
                                            //零星领料
                                            DTcms.Model.w_inout_detail inout = new DTcms.Model.w_inout_detail();
                                            inout.FK_BillID = globalField.BillID;
                                            inout.FK_SendBillNum = approve.ApplyPartNum;
                                            inout.FK_ApproveNum = approve.ApproveNum;
                                            inout.BarCode = tool.BarCode;
                                            inout.BatchNumber = tool.BatchNumber;
                                            inout.MaterialID = tool.MaterialID;
                                            inout.MaterialName = tool.MaterialName;
                                            inout.MaterialTypeID = tool.MaterialTypeID;
                                            inout.MaterialType = tool.MaterialType;
                                            inout.SystemNo = tool.SystemNo;
                                            inout.Brand = tool.Brand;
                                            inout.Spec = tool.Spec;
                                            inout.Unit = tool.Unit;
                                            inout.Num = tool.Num;
                                            inout.IOFlag = -1;
                                            inout.InOutType = "计划零星领用";
                                            inout.FK_ShelfID = shelf.ID;
                                            inout.X = tool.X;
                                            inout.Y = tool.Y;
                                            //计算工作寿命
                                            decimal ReduceWorkTime = 0;
                                            ReduceWorkTime = Convert.ToDecimal(approve.ApplyWorkTime);
                                            string sql = "select * from sy_material_texture where MaterialID = '" + tool.MaterialID + "' and Texture = '" + approve.Texture + "'";
                                            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                                            if (dt != null && dt.Rows.Count > 0)
                                            {
                                                ReduceWorkTime = Convert.ToDecimal(dt.Rows[0]["Coefficient"]) * ReduceWorkTime;
                                            }
                                            inout.WorkTime = ReduceWorkTime;
                                            inout.OperatorName = globalField.Manager.real_name;
                                            inout.OperatorTime = DateTime.Now;
                                            inout.InOutRemark = "";
                                            //添加领用记录
                                            new DTcms.BLL.w_inout_detail().Add(inout);
                                            //修改CAM表状态
                                            sql = "update temp_camlist set ToolReadyState = 2 where Id = " + approve.ApplyCamId.ToString();
                                            DbHelperMySql.ExecuteSql(sql);
                                            //修改道具在库状态，剩余加工寿命，道具等级
                                            tool.State = 2;
                                            if (tool.ToolLevel == "X")//如果是新刀，改为旧刀
                                            {
                                                tool.ToolLevel = "F";
                                            }
                                            tool.RemainTime = tool.RemainTime - Convert.ToInt32(ReduceWorkTime);
                                            new DTcms.BLL.w_barcode().Update(tool);
                                            //更新审核表状态
                                            approve.ApproveState = 2;
                                            new DTcms.BLL.w_approvelist().Update(approve);
                                            //循环CAM表状态，是否更新任务令表状态
                                            List<DTcms.Model.temp_camlist> camlist = new DTcms.BLL.temp_camlist().GetModelList("PartNum = '" + approve.ApplyPartNum + "'");
                                            bool isDone = true;
                                            foreach (DTcms.Model.temp_camlist item in camlist)
                                            {
                                                if (item.ToolReadyState == 2)//已领刀
                                                {
                                                    continue;
                                                }
                                                else if (item.ToolReadyState == -1)//有一把异常，主表状态就为异常
                                                {
                                                    //DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + approve.ApplyPartNum + "'")[0];
                                                    //planorder.OrderReadyState = -1;
                                                    //new DTcms.BLL.temp_planorderlist().Update(planorder);
                                                    isDone = false;
                                                    break;
                                                }
                                                else if (item.ToolReadyState == 1)//有一把未领，主表状态就为未领
                                                {
                                                    //DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + approve.ApplyPartNum + "'")[0];
                                                    //planorder.OrderReadyState = 1;
                                                    //new DTcms.BLL.temp_planorderlist().Update(planorder);
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
                                                DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + approve.ApplyPartNum + "'")[0];
                                                planorder.OrderReadyState = 2;
                                                new DTcms.BLL.temp_planorderlist().Update(planorder);
                                            }
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
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择在申请列表中选择申请刀具！");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvCamList.SelectedRows != null && dgvCamList.SelectedRows.Count > 0)
            {
                string id = dgvCamList.SelectedRows[0].Cells[0].Value.ToString();
                DTcms.Model.temp_camlist cam = new DTcms.BLL.temp_camlist().GetModel(int.Parse(id));
                if (cam != null)
                {
                    if (MessageBox.Show("确认申请刀具：" + cam.ToolName + "？", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        DTcms.Model.w_approvelist approve = new DTcms.Model.w_approvelist();
                        approve.ApproveNum = DateTime.Now.ToString("yyyyMMddHHmmss" + globalField.Manager.id.ToString());
                        approve.CreateDate = DateTime.Now;
                        approve.CreateById = globalField.Manager.id;
                        approve.CreateByName = globalField.Manager.real_name;
                        approve.ApplyRemark = "";
                        approve.IsPlanApprove = 1;
                        approve.ApproveState = 0;
                        approve.ApplyPartNum = cam.PartNum;
                        approve.ApplyCamId = cam.Id;
                        approve.ApplyToolName = cam.ToolName;
                        approve.ApplyWorkTime = cam.WorkTime;
                        approve.ApplyToolLevel = cam.ToolLevel;
                        approve.ApplyOldToolBarCode = cam.ToolBarCode;
                        approve.ApproveById = null;
                        approve.ApproveByName = null;
                        approve.ApproveDate = null;
                        approve.ApproveNewToolBarCode = null;
                        approve.ApproveRemark = null;
                        approve.Texture = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + cam.PartNum + "'")[0].MaterialTexture;
                        if (new DTcms.BLL.w_approvelist().Add(approve))
                        {
                            MessageBox.Show("申请成功！");
                            txtPartNum.Text = "";
                            string sql = "select Id,PartNum,ToolName,WorkTime,ToolLevel,(CASE ToolReadyState WHEN 0 THEN '待备刀' WHEN 1 THEN '备刀中' WHEN 2 THEN '已领刀' WHEN -1 THEN '异常' WHEN -1 THEN '已取消' ELSE '其他' END) as ToolState from temp_camlist where 1=2";
                            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                            dgvCamList.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("申请失败！");
                        }
                    }
                }
                GetApproveList();
            }
            else
            {
                MessageBox.Show("请在CAM清单中选择您需要的刀具！");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetApproveList();
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

        private void btnQueryPart_Click(object sender, EventArgs e)
        {
            string sql = "select Id,PartNum,ToolName,WorkTime,ToolLevel,(CASE ToolReadyState WHEN 0 THEN '待备刀' WHEN 1 THEN '备刀中' WHEN 2 THEN '已领刀' WHEN -1 THEN '异常' WHEN -1 THEN '已取消' ELSE '其他' END) as ToolState from temp_camlist where PartNum = '" + txtPartNum.Text + "'";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvCamList.DataSource = dt;
            }
            else
            {
                MessageBox.Show("没有符合条件的零件号！");
            }
        }

        private void dgvCamList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvCamList.Rows.Count; i++)
            {
                if (dgvCamList.Rows[i].Cells[5].Value.ToString() == "已领刀")
                {
                    this.dgvCamList.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (dgvCamList.Rows[i].Cells[5].Value.ToString() == "异常")
                {
                    this.dgvCamList.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}
