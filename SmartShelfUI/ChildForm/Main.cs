using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

        SocketWrapper MySocket;
        private void Main_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //初始化tcpip连接
            try
            {
                MySocket = new SocketWrapper(ConfigurationManager.AppSettings["serverip"], int.Parse(ConfigurationManager.AppSettings["serverport"]));
                MySocket.CommandArrival += new SocketWrapper.CommandArrivalEventHandler(client_PlaintextReceived);
                if (MySocket.Socket_Create_Connect())
                {
                    MySocket.Run();
                }
                else
                {
                    thStartSocket = new Thread(StartSocket);
                    thStartSocket.Start();
                    MessageBox.Show("连接失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Utils.WriteError("初始化tcpip连接", ex.ToString() + "\n" + ex.StackTrace);
            }
            showFormLogin();
        }

        Thread thStartSocket;
        void StartSocket()
        {
            while (!MySocket.IsConnect)
            {
                try
                {
                    MySocket.Socket_Create_Connect();
                    Thread.Sleep(2000);
                }
                catch (Exception)
                { }
            }
            if (MySocket.IsConnect)
            {
                MySocket.Run();
            }
        }

        //ChildForm.CellsLocation frmCellsLocation;
        void closeCells(string cabinetAdr, string shelfAdr)
        {
            //if (frmCellsLocation != null || !frmCellsLocation.IsDisposed)
            //{
            //    frmCellsLocation = null;
            //}
        }
        void client_PlaintextReceived(object sender, SocketWrapper.MyEventArgs e)
        {
            if (e.CommandBuf != null)
            {
                int inLen = e.CommandBuf.Length;
                byte[] receiveByte = new byte[inLen];
                Array.Copy(e.CommandBuf, 0, receiveByte, 0, inLen);
                if (VerifyReceive(receiveByte))
                {
                    Utils.Writelog(return0xStr(receiveByte[0]) + " " + return0xStr(receiveByte[1]) + " " + return0xStr(receiveByte[2]) + " " + return0xStr(receiveByte[3]) + " " + return0xStr(receiveByte[4]) + " " + return0xStr(receiveByte[5]), "收到验证通过的tcpip反馈");
                    #region 正常打开 或 已经开着
                    if (receiveByte[3] == 0x01 || receiveByte[3] == 0x00)
                    {
                        if (this.OpenLockType == unlockTypeEnum.计划领料)
                        {
                            if (dic_wait_for_open_shelf != null && dic_wait_for_open_shelf.Count > 0)
                            {
                                string cabinetAdr = return0xStr(receiveByte[1]);
                                string shelfAdr = return0xStr(receiveByte[2]);
                                DTcms.Model.sy_cabinet cabinet = new DTcms.BLL.sy_cabinet().GetModelList("CardAddr = '" + cabinetAdr + "'")[0];
                                DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModelList("FK_CabinetNo = '" + cabinet.CabinetNo + "' and BoxAddr = '" + shelfAdr + "'")[0];
                                dic_wait_for_open_shelf[shelf.ID.ToString()] = 1;

                                string sql = "select w.X,w.Y,w.BarCode from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.FK_Id = '" + PartID + "' and s.ID = " + shelf.ID;
                                DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                                //frmCellsLocation = new ChildForm.CellsLocation();
                                //frmCellsLocation.closeForm += new ChildForm.CellsLocation.FormHandle(closeCells);
                                //frmCellsLocation.ShelfID = shelf.ID;
                                //frmCellsLocation.PartNum = new DTcms.BLL.temp_planorderlist().GetModel(int.Parse(PartID)).PartNum;
                                //frmCellsLocation.PartId = PartID;

                                ChildForm.CellsLocation.Instance.ShelfID = shelf.ID;
                                ChildForm.CellsLocation.Instance.PartNum = new DTcms.BLL.temp_planorderlist().GetModel(int.Parse(PartID)).PartNum;
                                ChildForm.CellsLocation.Instance.PartId = PartID;
                                ChildForm.CellsLocation.Instance.closeForm += new ChildForm.CellsLocation.FormHandle(closeCells);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    ChildForm.CellsLocation.Instance.lstSelected = new List<string>();
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        ChildForm.CellsLocation.Instance.lstSelected.Add(dt.Rows[i]["X"].ToString() + "-" + dt.Rows[i]["Y"].ToString() + "-" + dt.Rows[i]["BarCode"].ToString());
                                        //frmCellsLocation.lstSelected.Add(dt.Rows[i]["X"].ToString() + "-" + dt.Rows[i]["Y"].ToString() + "-" + dt.Rows[i]["BarCode"].ToString());
                                    }
                                }
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    //frmCellsLocation.ShowDialog();
                                    ChildForm.CellsLocation.Instance.ShowDialog();
                                });
                            }
                        }
                        else if (this.OpenLockType == unlockTypeEnum.计划零星领料)
                        {
                            ChildForm.CellsLocationForGeneral frmCells = new ChildForm.CellsLocationForGeneral(true);
                            frmCells.tool = tool;
                            frmCells.cabinet = cabinet;
                            frmCells.shelf = shelf;
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
                                List<DTcms.Model.temp_camlist> camlist = new DTcms.BLL.temp_camlist().GetModelList("FK_Id = " + approve.ApplyPartNum + "");
                                bool isDone = true;
                                foreach (DTcms.Model.temp_camlist item in camlist)
                                {
                                    if (item.ToolReadyState == 2)//已领刀
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
                                    //DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModelList("PartNum = '" + approve.ApplyPartNum + "'")[0];
                                    DTcms.Model.temp_planorderlist planorder = new DTcms.BLL.temp_planorderlist().GetModel(int.Parse(approve.ApplyPartNum));
                                    planorder.OrderReadyState = 2;
                                    new DTcms.BLL.temp_planorderlist().Update(planorder);
                                }
                            }
                        }
                        else if (this.OpenLockType == unlockTypeEnum.非计划零星领料)
                        {
                            ChildForm.CellsLocationForGeneral frmCells = new ChildForm.CellsLocationForGeneral(true);
                            frmCells.tool = tool;
                            frmCells.cabinet = cabinet;
                            frmCells.shelf = shelf;

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
                        else if (this.OpenLockType == unlockTypeEnum.归还)
                        {
                            ChildForm.CellsLocationForGeneral frmCells = new ChildForm.CellsLocationForGeneral();
                            frmCells.tool = this.tool;
                            frmCells.cabinet = this.cabinet;
                            frmCells.shelf = this.shelf;
                            if (this.tool.State != 2)
                            {
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("该刀具状态错误！(非出库状态中)");
                                });
                                return;
                            }
                            else
                            {
                                if (frmCells.ShowDialog() == DialogResult.OK)
                                {
                                    //修改刀具状态
                                    tool.State = 1;
                                    new DTcms.BLL.w_barcode().Update(tool);
                                    //生成归还记录
                                    DTcms.Model.w_inout_detail inout = new DTcms.Model.w_inout_detail();
                                    inout.FK_BillID = globalField.BillID;
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
                                    inout.IOFlag = 1;
                                    List<DTcms.Model.w_inout_detail> lstdetail = new DTcms.BLL.w_inout_detail().GetModelList("BarCode = '" + tool.BarCode + "' and IOFlag = -1 order by OperatorTime desc");
                                    if (lstdetail != null && lstdetail.Count > 0)
                                    {
                                        inout.FK_SendBillNum = lstdetail[0].FK_SendBillNum;
                                        inout.FK_ApproveNum = lstdetail[0].FK_ApproveNum;
                                        inout.InOutType = lstdetail[0].InOutType.Replace("领用", "归还");
                                    }
                                    inout.FK_ShelfID = shelf.ID;
                                    inout.X = shelf.X;
                                    inout.Y = shelf.Y;
                                    inout.WorkTime = 0;
                                    inout.OperatorName = globalField.Manager.real_name;
                                    inout.OperatorTime = DateTime.Now;
                                    inout.InOutRemark = "";
                                    new DTcms.BLL.w_inout_detail().Add(inout);
                                }
                            }
                        }
                        else if (this.OpenLockType == unlockTypeEnum.入库)
                        {
                            ChildForm.CellsLocationForGeneral frmCells = new ChildForm.CellsLocationForGeneral();
                            frmCells.tool = this.tool;
                            frmCells.cabinet = this.cabinet;
                            frmCells.shelf = this.shelf;
                            if (frmCells.ShowDialog() == DialogResult.OK)
                            {
                                //修改刀具状态
                                tool.State = 1;
                                new DTcms.BLL.w_barcode().Update(tool);
                                //生成入库记录
                                DTcms.Model.w_inout_detail inout = new DTcms.Model.w_inout_detail();
                                inout.FK_BillID = globalField.BillID;
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
                                inout.IOFlag = 1;
                                inout.FK_SendBillNum = null;
                                inout.FK_ApproveNum = null;
                                inout.InOutType = "入库";
                                inout.FK_ShelfID = shelf.ID;
                                inout.X = shelf.X;
                                inout.Y = shelf.Y;
                                inout.WorkTime = 0;
                                inout.OperatorName = globalField.Manager.real_name;
                                inout.OperatorTime = DateTime.Now;
                                inout.InOutRemark = "";
                                new DTcms.BLL.w_inout_detail().Add(inout);
                            }
                        }
                        else if (this.OpenLockType == unlockTypeEnum.修磨刀入库)
                        {
                            ChildForm.CellsLocationForGeneral frmCells = new ChildForm.CellsLocationForGeneral();
                            frmCells.tool = this.tool;
                            frmCells.cabinet = this.cabinet;
                            frmCells.shelf = this.shelf;
                            if (frmCells.ShowDialog() == DialogResult.OK)
                            {
                                //修改刀具状态
                                tool.State = 1;
                                tool.ToolLevel = "R";
                                tool.RemainTime = decimal.Parse(worktime);
                                new DTcms.BLL.w_barcode().Update(tool);
                                //生成修磨入库记录
                                DTcms.Model.w_inout_detail inout = new DTcms.Model.w_inout_detail();
                                inout.FK_BillID = globalField.BillID;
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
                                inout.IOFlag = 1;
                                inout.FK_SendBillNum = null;
                                inout.FK_ApproveNum = null;
                                inout.InOutType = "修磨入库";
                                inout.FK_ShelfID = shelf.ID;
                                inout.X = shelf.X;
                                inout.Y = shelf.Y;
                                inout.WorkTime = 0;
                                inout.OperatorName = globalField.Manager.real_name;
                                inout.OperatorTime = DateTime.Now;
                                inout.InOutRemark = "";
                                new DTcms.BLL.w_inout_detail().Add(inout);
                            }
                        }
                        else if (this.OpenLockType == unlockTypeEnum.盘点)
                        {
                            return;
                        }
                    }
                    #endregion
                    #region 关门反馈
                    else if (receiveByte[3] == 0x02)
                    {
                        if (this.OpenLockType == unlockTypeEnum.计划领料)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                ChildForm.CellsLocation.Instance.Close();
                            });
                            //if (frmCellsLocation != null)
                            //{
                            //    this.BeginInvoke((MethodInvoker)delegate
                            //    {
                            //        frmCellsLocation.Close();
                            //        frmCellsLocation = null;
                            //    });
                            //}
                            if (dic_wait_for_open_shelf != null && dic_wait_for_open_shelf.Count > 0)
                            {
                                string cabinetAdr = return0xStr(receiveByte[1]);
                                string shelfAdr = return0xStr(receiveByte[2]);
                                DTcms.Model.sy_cabinet cabinet = new DTcms.BLL.sy_cabinet().GetModelList("CardAddr = '" + cabinetAdr + "'")[0];
                                DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModelList("FK_CabinetNo = '" + cabinet.CabinetNo + "' and BoxAddr = '" + shelfAdr + "'")[0];
                                dic_wait_for_open_shelf[shelf.ID.ToString()] = 2;
                            }
                            bool isAllOpened = true;
                            foreach (KeyValuePair<string, int> item in dic_wait_for_open_shelf)
                            {
                                if (item.Value == 0)
                                {
                                    isAllOpened = false;
                                    DTcms.Model.sy_shelf next_shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(item.Key));
                                    DTcms.Model.sy_cabinet next_cabinet = new DTcms.BLL.sy_cabinet().GetModel(next_shelf.FK_CabinetNo);
                                    byte[] code_byte = new byte[6];
                                    code_byte[0] = 0xFF;
                                    code_byte[1] = (byte)Convert.ToInt32(next_cabinet.CardAddr, 16);
                                    code_byte[2] = (byte)Convert.ToInt32(next_shelf.BoxAddr, 16);
                                    code_byte[3] = 0x01;
                                    code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                                    code_byte[5] = 0xFE;
                                    MySocket.SyncSend(code_byte);
                                    break;
                                }
                            }
                            if (isAllOpened)//如果所有待开的锁都打开过了
                            {
                                if (frmPick != null)
                                {
                                    Panel panel_shelf = frmPick.Controls.Find("panel_shelf", true)[0] as Panel;
                                    frmPick.BeginInvoke((MethodInvoker)delegate
                                    {
                                        panel_shelf.Controls.Clear();
                                    });
                                    int i = 0;
                                    foreach (KeyValuePair<string, int> item in dic_wait_for_open_shelf)
                                    {
                                        DTcms.Model.sy_shelf this_shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(item.Key));

                                        Button btnShelf = new Button();
                                        btnShelf.FlatAppearance.BorderSize = 0;
                                        btnShelf.FlatStyle = FlatStyle.Flat;
                                        btnShelf.Font = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                        btnShelf.ForeColor = Color.White;
                                        btnShelf.Location = new Point(8, 40 * i + 8);
                                        btnShelf.Size = new Size(190, 35);
                                        btnShelf.UseVisualStyleBackColor = true;
                                        btnShelf.Text = this_shelf.FK_CabinetNo + "号柜" + this_shelf.BoxNo + "号抽屉";
                                        if (item.Value == -1)
                                        {
                                            btnShelf.BackColor = Color.Red;
                                        }
                                        else if (item.Value == 1)
                                        {
                                            btnShelf.BackColor = Color.Yellow;
                                        }
                                        else if (item.Value == 2)
                                        {
                                            btnShelf.BackColor = Color.Green;
                                        }
                                        frmPick.BeginInvoke((MethodInvoker)delegate
                                        {
                                            panel_shelf.Controls.Add(btnShelf);
                                        });
                                        i++;
                                    }
                                    frmPick.BeginInvoke((MethodInvoker)delegate
                                    {
                                        frmPick.GetOrderList();
                                        frmPick.GetCamList();
                                    });
                                    dic_wait_for_open_shelf.Clear();
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    #endregion
                    #region 开门失败
                    else
                    {
                        if (this.OpenLockType == unlockTypeEnum.计划领料)
                        {
                            DTcms.Model.sy_cabinet cabinet;
                            DTcms.Model.sy_shelf shelf;
                            string cabinetAdr = return0xStr(receiveByte[1]);
                            string shelfAdr = return0xStr(receiveByte[2]);
                            cabinet = new DTcms.BLL.sy_cabinet().GetModelList("CardAddr = '" + cabinetAdr + "'")[0];
                            shelf = new DTcms.BLL.sy_shelf().GetModelList("FK_CabinetNo = '" + cabinet.CabinetNo + "' and BoxAddr = '" + shelfAdr + "'")[0];
                            if (dic_wait_for_open_shelf != null && dic_wait_for_open_shelf.Count > 0)
                            {
                                dic_wait_for_open_shelf[shelf.ID.ToString()] = -1;
                            }

                            bool isAllOpened = true;
                            foreach (KeyValuePair<string, int> item in dic_wait_for_open_shelf)
                            {
                                if (item.Value == 0)
                                {
                                    isAllOpened = false;
                                    DTcms.Model.sy_shelf next_shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(item.Key));
                                    DTcms.Model.sy_cabinet next_cabinet = new DTcms.BLL.sy_cabinet().GetModel(next_shelf.FK_CabinetNo);
                                    byte[] code_byte = new byte[6];
                                    code_byte[0] = 0xFF;
                                    code_byte[1] = (byte)Convert.ToInt32(next_cabinet.CardAddr, 16);
                                    code_byte[2] = (byte)Convert.ToInt32(next_shelf.BoxAddr, 16);
                                    code_byte[3] = 0x01;
                                    code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                                    code_byte[5] = 0xFE;
                                    MySocket.SyncSend(code_byte);
                                    break;
                                }
                            }
                            if (isAllOpened)//如果所有待开的锁都打开过了
                            {
                                if (frmPick != null)
                                {
                                    Panel panel_shelf = frmPick.Controls.Find("panel_shelf", false)[0] as Panel;
                                    panel_shelf.Controls.Clear();
                                    int i = 0;
                                    foreach (KeyValuePair<string, int> item in dic_wait_for_open_shelf)
                                    {
                                        DTcms.Model.sy_shelf this_shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(item.Key));

                                        Button btnShelf = new Button();
                                        btnShelf.FlatAppearance.BorderSize = 0;
                                        btnShelf.FlatStyle = FlatStyle.Flat;
                                        btnShelf.Font = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                        btnShelf.ForeColor = Color.White;
                                        btnShelf.Location = new Point(8, 35 * i + 8);
                                        btnShelf.Size = new Size(190, 35);
                                        btnShelf.UseVisualStyleBackColor = true;
                                        btnShelf.Text = this_shelf.FK_CabinetNo + "号柜" + this_shelf.BoxNo + "号抽屉";
                                        if (item.Value == -1)
                                        {
                                            btnShelf.BackColor = Color.Red;
                                        }
                                        else if (item.Value == 1)
                                        {
                                            btnShelf.BackColor = Color.Yellow;
                                        }
                                        else if (item.Value == 2)
                                        {
                                            btnShelf.BackColor = Color.Green;
                                        }
                                        panel_shelf.Controls.Add(btnShelf);
                                        i++;
                                    }
                                    frmPick.GetCamList();
                                    dic_wait_for_open_shelf.Clear();
                                }
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show(cabinet.CabinetNo + "号柜 " + shelf.BoxNo + "号抽屉开锁失败！");
                                });
                            }
                        }
                        else
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("开锁失败！");
                            });
                        }
                    }
                    #endregion
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("网络通讯返回错误！");
                    });
                }
            }
        }

        private string return0xStr(byte b)
        {
            string str = b.ToString("x6");
            string return_str = "";
            return_str = str.Substring(str.Length - 2, 2);
            return_str = "0x" + return_str.ToUpper();
            return return_str;
        }

        private bool VerifyReceive(byte[] receive)
        {
            if (receive.Length < 6)
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

        ChildForm.Login frmLogin = null;
        ChildForm.Pick frmPick = null;
        ChildForm.Menu frmMenu = null;
        ChildForm.Return frmReturn = null;
        ChildForm.ManageWeb frmManageWeb = null;
        ChildForm.DisPick_Plan frmDisPick_Plan = null;
        ChildForm.DisPick_UnPlan frmDisPick_UnPlan = null;
        ChildForm.Warehousing frmWarehousing = null;
        ChildForm.Userscard frmUserscard = null;
        ChildForm.Repair frmRepair = null;
        ChildForm.Stock frmStock = null;
        void showFormLogin()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            globalField.Manager = null;
            globalField.BillID = "";
            lblUserName.Visible = false;
            pxb_loginface.Visible = false;
            frmLogin = new ChildForm.Login();
            frmLogin.nextForm += new ChildForm.Login.FormHandle(showFormPick);
            frmLogin.TopLevel = false;
            panel_content.Controls.Add(frmLogin);
            frmLogin.Show();
        }
        void showFormPick()
        {
            if (frmLogin != null)
            {
                frmLogin.Close();
                frmLogin = null;
            }
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmPick = new ChildForm.Pick();
            frmPick.nextForm_menu += new ChildForm.Pick.FormHandle(showFormMenu);
            frmPick.nextForm_exit += new ChildForm.Pick.FormHandle(showFormLogin);
            //frmPick.nextForm_dispick_plan += new ChildForm.Pick.FormHandle(showFormDisPick_Plan);
            frmPick.nextForm_dispick_plan_partnum += new ChildForm.Pick.FormHandle2(showFormDisPick_Plan_partnum);
            frmPick.nextForm_dispick_unplan += new ChildForm.Pick.FormHandle(showFormDisPick_UnPlan);
            frmPick.sendShelfCode += new ChildForm.Pick.SendHandle(OpenShelfList);

            frmPick.TopLevel = false;
            panel_content.Controls.Add(frmPick);
            frmPick.Show();
            if (globalField.Manager != null)
            {
                pxb_loginface.Visible = true;
                lblUserName.Visible = true;
                lblUserName.Text = "欢迎使用\r\n" + globalField.Manager.real_name;
            }
        }
        void showFormMenu()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            if (frmReturn != null)
            {
                frmReturn.Close();
                frmReturn = null;
            }
            if (frmManageWeb != null)
            {
                frmManageWeb.Close();
                frmManageWeb = null;
            }
            if (frmDisPick_Plan != null)
            {
                frmDisPick_Plan.Close();
                frmDisPick_Plan = null;
            }
            if (frmDisPick_UnPlan != null)
            {
                frmDisPick_UnPlan.Close();
                frmDisPick_UnPlan = null;
            }
            if (frmWarehousing != null)
            {
                frmWarehousing.Close();
                frmWarehousing = null;
            }
            if (frmUserscard != null)
            {
                frmUserscard.Close();
                frmUserscard = null;
            }
            if (frmStock != null)
            {
                frmStock.Close();
                frmStock = null;
            }
            if (frmRepair != null)
            {
                frmRepair.Close();
                frmRepair = null;
            }
            frmMenu = new ChildForm.Menu();
            frmMenu.nextForm_return += new ChildForm.Menu.FormHandle(showFormReturn);
            frmMenu.nextForm_repair += new ChildForm.Menu.FormHandle(showFormRepair);
            frmMenu.nextForm_users += new ChildForm.Menu.FormHandle(showFormUsers);
            frmMenu.nextForm_warehouse += new ChildForm.Menu.FormHandle(showFormWarehouse);
            frmMenu.nextForm_stock += new ChildForm.Menu.FormHandle(showFormStock);
            frmMenu.nextForm_pick += new ChildForm.Menu.FormHandle(showFormPick);
            frmMenu.nextForm_exit += new ChildForm.Menu.FormHandle(showFormLogin);
            frmMenu.nextForm_web += new ChildForm.Menu.FormHandle(showFormWeb);
            frmMenu.TopLevel = false;
            panel_content.Controls.Add(frmMenu);
            frmMenu.Show();
        }

        //void showFormDisPick_Plan()
        //{
        //    if (frmPick != null)
        //    {
        //        frmPick.Close();
        //        frmPick = null;
        //    }
        //    frmDisPick_Plan = new ChildForm.DisPick_Plan();
        //    frmDisPick_Plan.TopLevel = false;
        //    frmDisPick_Plan.sendCode += new ChildForm.DisPick_Plan.SendHandle(OpenDoor_DisPick_Plan);
        //    panel_content.Controls.Add(frmDisPick_Plan);
        //    frmDisPick_Plan.Show();
        //    btnBack.Visible = true;
        //}
        void showFormDisPick_Plan_partnum(int partid)
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            frmDisPick_Plan = new ChildForm.DisPick_Plan(partid);
            frmDisPick_Plan.TopLevel = false;
            frmDisPick_Plan.sendCode += new ChildForm.DisPick_Plan.SendHandle(OpenDoor_DisPick_Plan);
            panel_content.Controls.Add(frmDisPick_Plan);
            frmDisPick_Plan.Show();
            btnBack.Visible = true;
        }
        void showFormDisPick_UnPlan()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            frmDisPick_UnPlan = new ChildForm.DisPick_UnPlan();
            frmDisPick_UnPlan.TopLevel = false;
            frmDisPick_UnPlan.sendCode += new ChildForm.DisPick_UnPlan.SendHandle(OpenDoor_DisPick_UnPlan);
            panel_content.Controls.Add(frmDisPick_UnPlan);
            frmDisPick_UnPlan.Show();
            btnBack.Visible = true;
        }

        void showFormReturn()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmReturn = new ChildForm.Return();
            frmReturn.nextForm_exit += new ChildForm.Return.FormHandle(showFormMenu);
            frmReturn.sendCode += new ChildForm.Return.SendHandle(OpenDoor_Return);
            frmReturn.TopLevel = false;
            panel_content.Controls.Add(frmReturn);
            frmReturn.Show();
            btnBack.Visible = true;
        }
        void showFormRepair()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmRepair = new ChildForm.Repair();
            frmRepair.sendCode += new ChildForm.Repair.SendHandle(OpenDoor_Repair);
            frmRepair.TopLevel = false;
            panel_content.Controls.Add(frmRepair);
            frmRepair.Show();
            btnBack.Visible = true;
        }
        void showFormUsers()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmUserscard = new ChildForm.Userscard();
            frmUserscard.TopLevel = false;
            panel_content.Controls.Add(frmUserscard);
            frmUserscard.Show();
            btnBack.Visible = true;
        }
        void showFormWarehouse()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmWarehousing = new ChildForm.Warehousing();
            //frmWarehousing.nextForm_exit += new ChildForm.Return.FormHandle(showFormMenu);
            frmWarehousing.sendCode += new ChildForm.Warehousing.SendHandle(OpenDoor_Warehousing);
            frmWarehousing.TopLevel = false;
            panel_content.Controls.Add(frmWarehousing);
            frmWarehousing.Show();
            btnBack.Visible = true;
        }
        void showFormStock()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmStock = new ChildForm.Stock();
            frmStock.sendCode += new ChildForm.Stock.SendHandle(OpenDoor_Stock);
            frmStock.TopLevel = false;
            panel_content.Controls.Add(frmStock);
            frmStock.Show();
            btnBack.Visible = true;
        }
        void showFormWeb()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmManageWeb = new ChildForm.ManageWeb();
            //frmManageWeb.nextForm_exit += new ChildForm.Return.FormHandle(frmManageWeb);
            frmManageWeb.TopLevel = false;
            panel_content.Controls.Add(frmManageWeb);
            frmManageWeb.Show();
            btnBack.Visible = true;
        }
        /// <summary>
        /// 回到主菜单界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            showFormMenu();
            btnBack.Visible = false;
        }

        unlockTypeEnum OpenLockType;
        string PartID;
        DTcms.Model.w_barcode tool;
        DTcms.Model.sy_shelf shelf;
        DTcms.Model.sy_cabinet cabinet;
        DTcms.Model.w_approvelist approve;
        /// <summary>
        /// 等待开锁列表开锁
        /// </summary>
        /// <param name="lst_shelf_id"></param>
        void OpenShelfList(List<string> lst_shelf_id, string Part_ID)
        {
            OpenLockType = unlockTypeEnum.计划领料;
            dic_wait_for_open_shelf.Clear();
            this.PartID = Part_ID;
            if (lst_shelf_id != null && lst_shelf_id.Count > 0)
            {
                for (int i = 0; i < lst_shelf_id.Count; i++)
                {
                    dic_wait_for_open_shelf.Add(lst_shelf_id[i], 0);
                }
                DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(lst_shelf_id[0]));
                DTcms.Model.sy_cabinet cabinet = new DTcms.BLL.sy_cabinet().GetModel(shelf.FK_CabinetNo);

                byte[] code_byte = new byte[6];
                code_byte[0] = 0xFF;
                code_byte[1] = (byte)Convert.ToInt32(cabinet.CardAddr, 16);
                code_byte[2] = (byte)Convert.ToInt32(shelf.BoxAddr, 16);
                code_byte[3] = 0x01;
                code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                code_byte[5] = 0xFE;
                MySocket.SyncSend(code_byte);
            }
        }
        /// <summary>
        /// 0:待开锁 1:已开 2:已关 -1:开锁失败
        /// </summary>
        Dictionary<string, int> dic_wait_for_open_shelf = new Dictionary<string, int>();

        /// <summary>
        /// 计划零星领料开锁
        /// </summary>
        /// <param name="send_byte"></param>
        void OpenDoor_DisPick_Plan(byte[] send_byte, unlockTypeEnum type, DTcms.Model.w_barcode _tool, DTcms.Model.sy_shelf _shelf, DTcms.Model.sy_cabinet _cabinet, DTcms.Model.w_approvelist _approve)
        {
            OpenLockType = type;
            this.tool = _tool;
            this.shelf = _shelf;
            this.cabinet = _cabinet;
            this.approve = _approve;
            MySocket.SyncSend(send_byte);
        }

        /// <summary>
        /// 非计划零星领料开锁
        /// </summary>
        void OpenDoor_DisPick_UnPlan(byte[] send_byte, unlockTypeEnum type, DTcms.Model.w_barcode _tool, DTcms.Model.sy_shelf _shelf, DTcms.Model.sy_cabinet _cabinet, DTcms.Model.w_approvelist _approve)
        {
            OpenLockType = type;
            this.tool = _tool;
            this.shelf = _shelf;
            this.cabinet = _cabinet;
            this.approve = _approve;

            MySocket.SyncSend(send_byte);
        }
        /// <summary>
        /// 归还开锁
        /// </summary>
        void OpenDoor_Return(byte[] send_byte, unlockTypeEnum type, DTcms.Model.w_barcode _tool, DTcms.Model.sy_shelf _shelf, DTcms.Model.sy_cabinet _cabinet)
        {
            OpenLockType = type;
            this.tool = _tool;
            this.shelf = _shelf;
            this.cabinet = _cabinet;

            MySocket.SyncSend(send_byte);
        }
        /// <summary>
        /// 入库开锁
        /// </summary>
        void OpenDoor_Warehousing(byte[] send_byte, unlockTypeEnum type, DTcms.Model.w_barcode _tool, DTcms.Model.sy_shelf _shelf, DTcms.Model.sy_cabinet _cabinet)
        {
            OpenLockType = type;
            this.tool = _tool;
            this.shelf = _shelf;
            this.cabinet = _cabinet;

            MySocket.SyncSend(send_byte);
        }
        string worktime;
        /// <summary>
        /// 修磨刀入库开锁
        /// </summary>
        void OpenDoor_Repair(byte[] send_byte, unlockTypeEnum type, DTcms.Model.w_barcode _tool, DTcms.Model.sy_shelf _shelf, DTcms.Model.sy_cabinet _cabinet, string _worktime)
        {
            OpenLockType = type;
            this.tool = _tool;
            this.shelf = _shelf;
            this.cabinet = _cabinet;
            this.worktime = _worktime;
            MySocket.SyncSend(send_byte);
        }
        /// <summary>
        /// 盘点开锁
        /// </summary>
        void OpenDoor_Stock(byte[] send_byte, unlockTypeEnum type, DTcms.Model.sy_shelf _shelf, DTcms.Model.sy_cabinet _cabinet)
        {
            OpenLockType = type;
            this.shelf = _shelf;
            this.cabinet = _cabinet;

            MySocket.SyncSend(send_byte);
        }
    }
}
