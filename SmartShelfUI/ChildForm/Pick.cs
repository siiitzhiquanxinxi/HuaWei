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
        public event FormHandle nextForm_exit;
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
            string sql = "select c.PartNum,c.ToolName,c.WorkTime,c.ToolLevel,s.FK_CabinetNo,s.BoxNo from temp_camlist c left join w_barcode w on w.BarCode = c.ToolBarCode left join sy_shelf s on s.ID = w.FK_ShelfID where c.PartNum = '" + PartNum + "'";
            sql += " order by s.FK_CabinetNo,s.BoxNo";
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

        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            Button btnOpenDoor = sender as Button;
            string cabinetNo = btnOpenDoor.Tag.ToString().Split('|')[0];
            string shelfNo = btnOpenDoor.Tag.ToString().Split('|')[1];
            string shelfId = btnOpenDoor.Tag.ToString().Split('|')[2];
            string PartNo = btnOpenDoor.Tag.ToString().Split('|')[3];

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

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            nextForm_exit();
        }
    }
}
