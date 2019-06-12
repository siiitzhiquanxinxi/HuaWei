﻿using System;
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

namespace SmartShelfUI.ChildForm
{
    public partial class CellsLocation : Form
    {
        public CellsLocation()
        {
            InitializeComponent();
            lstSelected = new List<string>();
        }
        public int ShelfID;
        public string PartNum;
        public List<string> lstSelected;

        private string inoutID = DateTime.Now.ToString("yyyyMMddHHmmssfff");

        private void CellsLocation_Load(object sender, EventArgs e)
        {
            this.spCom.PortName = ConfigurationManager.AppSettings["qrcom"].Trim();
            if (!spCom.IsOpen)
            {
                try
                { spCom.Open(); }
                catch
                { MessageBox.Show("串口打开失败！"); }
            }
            DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModel(ShelfID);
            if (shelf != null)
            {
                int x = Convert.ToInt16(shelf.X);
                int y = Convert.ToInt16(shelf.Y);
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Button b = new Button();
                        b.FlatAppearance.BorderSize = 0;
                        b.FlatStyle = FlatStyle.Flat;
                        b.Location = new Point(30 + 70 * i, 30 + 70 * j);
                        b.Size = new Size(60, 60);
                        b.Text = (i + 1).ToString() + "-" + (j + 1).ToString();
                        b.Font = new Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        b.BackColor = SystemColors.ControlDark;
                        foreach (string item in lstSelected)
                        {
                            if (item == (i + 1).ToString() + "-" + (j + 1).ToString())
                            {
                                b.BackColor = Color.Orange;
                            }
                        }
                        b.UseVisualStyleBackColor = true;
                        panel_Cells.Controls.Add(b);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void spCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);
            try
            {
                byte[] result = new byte[8];
                int rLength = spCom.Read(result, 0, result.Length);
                if (rLength >= 8)
                {
                    string barcode = result[0].ToString("x2") + result[1].ToString("x2") + result[2].ToString("x2") + result[3].ToString("x2") + result[4].ToString("x2") + result[5].ToString("x2") + result[6].ToString("x2") + result[7].ToString("x2");
                    List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("BarCode = '" + barcode.ToUpper() + "' and FK_ShelfID = " + ShelfID);
                    if (lstmodel != null && lstmodel.Count > 0)
                    {
                        //变颜色
                        foreach (Control item in panel_Cells.Controls)
                        {
                            if (item is Button)
                            {
                                Button b = item as Button;
                                if (b.Text.ToString() == lstmodel[0].X + "-" + lstmodel[0].Y)
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        b.BackColor = Color.Green;
                                        b.ForeColor = Color.White;
                                        lblToolBarcode.Text = lstmodel[0].BarCode;
                                        lblToolName.Text = lstmodel[0].MaterialName;
                                    });
                                    break;
                                }
                            }
                        }
                        if (lstmodel[0].State == 1)//判断物料在库状态
                        {
                            List<DTcms.Model.temp_camlist> lstcam = new DTcms.BLL.temp_camlist().GetModelList("ToolBarCode = '" + barcode + "' and PartNum = '" + PartNum + "'");
                            if (lstcam != null && lstcam.Count > 0 && lstcam[0].ToolReadyState == 1)
                            {
                                DTcms.Model.w_inout_detail inout = new DTcms.Model.w_inout_detail();
                                inout.FK_BillID = globalField.BillID;
                                inout.FK_SendBillNum = PartNum;
                                inout.FK_ApproveNum = null;
                                inout.BarCode = barcode;
                                inout.BatchNumber = lstmodel[0].BatchNumber;
                                inout.MaterialID = lstmodel[0].MaterialID;
                                inout.MaterialName = lstmodel[0].MaterialName;
                                inout.MaterialTypeID = lstmodel[0].MaterialTypeID;
                                inout.MaterialType = lstmodel[0].MaterialType;
                                inout.SystemNo = lstmodel[0].SystemNo;
                                inout.Brand = lstmodel[0].Brand;
                                inout.Spec = lstmodel[0].Spec;
                                inout.Unit = lstmodel[0].Unit;
                                inout.Num = lstmodel[0].Num;
                                inout.IOFlag = -1;
                                inout.InOutType = "计划领用";
                                inout.FK_ShelfID = ShelfID;
                                inout.X = lstmodel[0].X;
                                inout.Y = lstmodel[0].Y;
                                //计算工作寿命
                                decimal ReduceWorkTime = 0;
                                
                                ReduceWorkTime = Convert.ToDecimal(lstcam[0].WorkTime);
                                string sql = "select * from temp_planorderlist where PartNum = '" + PartNum + "'";
                                DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    string MaterialTexture = dt.Rows[0]["MaterialTexture"].ToString();
                                    sql = "select * from sy_material_texture where MaterialID = '" + lstmodel[0].MaterialID + "' and Texture = '" + MaterialTexture + "'";
                                    dt = DbHelperMySql.Query(sql).Tables[0];
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        ReduceWorkTime = Convert.ToDecimal(dt.Rows[0]["Coefficient"]) * ReduceWorkTime;
                                    }
                                }
                                inout.WorkTime = Convert.ToInt32(ReduceWorkTime);
                                inout.OperatorName = globalField.Manager.real_name;
                                inout.OperatorTime = DateTime.Now;
                                inout.InOutRemark = "";
                                //添加领用记录
                                new DTcms.BLL.w_inout_detail().Add(inout);
                                //修改CAM表状态
                                sql = "update temp_camlist set ToolReadyState = 2 where ToolBarCode = '" + barcode + "' and PartNum = '" + PartNum + "'";
                                DbHelperMySql.ExecuteSql(sql);
                                //修改道具在库状态，剩余加工寿命，道具等级
                                DTcms.Model.w_barcode tool = new DTcms.BLL.w_barcode().GetModel(barcode);
                                int RemainTime = 0;
                                tool.State = 2;
                                tool.RemainTime = RemainTime;
                                if (tool.ToolLevel == "X")//如果是新刀，改为旧刀
                                {
                                    tool.ToolLevel = "F";
                                }
                                tool.RemainTime = tool.RemainTime - Convert.ToInt32(ReduceWorkTime);
                                new DTcms.BLL.w_barcode().Update(tool);
                            }
                            else if (lstcam != null && lstcam.Count > 0 && lstcam[0].ToolReadyState != 1)
                            {
                                if (lstcam[0].ToolReadyState == 0)
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("该物料尚未备好料！");
                                    });
                                    return;
                                }
                                else if (lstcam[0].ToolReadyState == 2)
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("该物料已领取！");
                                    });
                                    return;
                                }
                                else
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("该物料状态异常！");
                                    });
                                    return;
                                }
                            }

                        }
                        else
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("该物料不在库！");
                            });
                            return;
                        }
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("物料不存在于该抽屉中！");
                        });
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void CellsLocation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spCom.IsOpen)
            {
                try
                {
                    spCom.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭串口失败：" + ex.ToString());
                }
            }
        }
    }
}
