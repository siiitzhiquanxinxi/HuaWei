using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class DisPick_UnPlan : Form
    {
        public DisPick_UnPlan()
        {
            InitializeComponent();
        }

        private void DisPick_UnPlan_Load(object sender, EventArgs e)
        {
            GetApproveList();
            string sql = "select Texture from sy_texture";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            cbxTexture.DataSource = dt;
            cbxTexture.ValueMember = "Texture";
        }

        private void GetApproveList()
        {
            string sql = "select ApproveNum,CreateDate,CreateByName,ApplyToolName,(CASE ApproveState WHEN 0 THEN '待审核' ELSE '已审核' END) as State from w_approvelist where (ApproveState = 0 or ApproveState = 1) and IsPlanApprove = 0 order by ApproveState desc,CreateDate desc";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            dgv_ApproveList.DataSource = dt;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtWorkTime.Text.Trim() == "")
            {
                MessageBox.Show("请输入加工时间！");
                return;
            }
            if (!IsNumber(txtWorkTime.Text))
            {
                MessageBox.Show("加工时间请输入数字！");
                return;
            }
            if (dgvTool.SelectedRows == null || dgvTool.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请在刀具列表中选择要申请的刀具！");
                return;
            }
            if (cbxTexture.Text == "")
            {
                MessageBox.Show("请选择加工材质！");
                return;
            }
            string toolLevel = "F";
            if (cbxToolLevel.Text == "")
            {
                MessageBox.Show("请选择刀具等级！");
                return;
            }
            else
            {
                if (cbxToolLevel.Text == "旧刀（F）")
                {
                    toolLevel = "F";
                }
                else if (cbxToolLevel.Text == "新刀（X）")
                {
                    toolLevel = "X";
                }
                else if (cbxToolLevel.Text == "返磨（R）")
                {
                    toolLevel = "R";
                }
            }
            DTcms.Model.w_approvelist approve = new DTcms.Model.w_approvelist();
            approve.ApproveNum = DateTime.Now.ToString("yyyyMMddHHmmss" + globalField.Manager.id.ToString());
            approve.CreateDate = DateTime.Now;
            approve.CreateById = globalField.Manager.id;
            approve.CreateByName = globalField.Manager.real_name;
            approve.ApplyRemark = "";
            approve.IsPlanApprove = 0;
            approve.ApproveState = 0;
            approve.ApplyPartNum = "";
            approve.ApplyToolName = dgvTool.SelectedRows[0].Cells[1].Value.ToString();
            approve.ApplyWorkTime = int.Parse(txtWorkTime.Text);
            approve.ApplyToolLevel = toolLevel;
            approve.ApplyOldToolBarCode = "";
            approve.ApproveById = null;
            approve.ApproveByName = null;
            approve.ApproveDate = null;
            approve.ApproveNewToolBarCode = null;
            approve.ApproveRemark = null;
            approve.Texture = cbxTexture.Text;
            if (new DTcms.BLL.w_approvelist().Add(approve))
            {
                MessageBox.Show("申请成功！");
                txtToolName.Text = txtWorkTime.Text = cbxToolLevel.Text = "";

                string sql = "select MaterialID,MaterialName,Brand,Spec from sy_material where 1=2";
                DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                dgvTool.DataSource = dt;
            }
            else
            {
                MessageBox.Show("申请失败！");
            }
            GetApproveList();
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
                                            //非计划零星领料
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
                                            inout.InOutType = "非计划零星领用";
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
                                            inout.WorkTime = Convert.ToInt32(ReduceWorkTime);
                                            inout.OperatorName = globalField.Manager.real_name;
                                            inout.OperatorTime = DateTime.Now;
                                            inout.InOutRemark = "";
                                            //添加领用记录
                                            new DTcms.BLL.w_inout_detail().Add(inout);

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetApproveList();
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        private void btnQueryTool_Click(object sender, EventArgs e)
        {
            if (txtToolName.Text.Trim() == "")
            {
                MessageBox.Show("请输入刀具名称！");
                return;
            }
            string sql = "select MaterialID,MaterialName,Brand,Spec from sy_material where State = 0 and MaterialName like '%" + txtToolName.Text.Trim() + "%'";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            dgvTool.DataSource = dt;

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
    }
}
