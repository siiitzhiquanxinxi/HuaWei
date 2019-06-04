using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            string sql = "select * from temp_planorderlist where OrderReadyState = 0 order by PlanWorkTime asc";
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
                    btnOrder.Click += btnOrder_Click;
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
            Button btn = sender as Button;
            string PartNum = btn.Tag.ToString();
            string sql = "select temp_camlist.PartNum,temp_camlist.ToolName,temp_camlist.WorkTime,temp_camlist.ToolLevel,w_barcode.CabinetNo,w_barcode.BoxNo from temp_camlist left join  w_barcode on w_barcode.BarCode = temp_camlist.ToolBarCode where temp_camlist.PartNum = '" + PartNum + "'";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvCamList.DataSource = dt;

                sql = "select distinct ";
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
                        btnShelf.TabIndex = 0;
                        btnShelf.Text = "打开" + dtShelf.Rows[i][""].ToString() + "号柜" + dtShelf.Rows[i][""].ToString() + "号抽屉";
                        btnShelf.UseVisualStyleBackColor = true;
                        panel_shelf.Controls.Add(btnShelf);
                    }
                }
            }
        }

        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            Button btnOpenDoor = sender as Button;
            string camId = btnOpenDoor.Tag.ToString();
            string sql = "select * from temp_camlist where Id = " + camId;
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                sql = "select * from toollist where ToolName = '" + dt.Rows[0]["ToolName"].ToString() + "'";
                dt = DbHelperMySql.Query(sql).Tables[0];
                ChildForm.CellsLocation frmCellsLocation = new CellsLocation();
                frmCellsLocation.ShelfID = 0;
                frmCellsLocation.lstSelected.Add("");
                frmCellsLocation.ShowDialog();
            }
        }
    }
}
