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
                    btnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    btnOrder.FlatAppearance.BorderSize = 0;
                    btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnOrder.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    btnOrder.ForeColor = System.Drawing.Color.White;
                    btnOrder.Location = new System.Drawing.Point(3, 3 + 55 * i);
                    btnOrder.Size = new System.Drawing.Size(540, 55);
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
            panel_CAM.Controls.Clear();
            Button btn = sender as Button;
            string PartNum = btn.Tag.ToString();
            string sql = "select * from temp_camlist where PartNum = '" + PartNum + "'";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvCamList.DataSource = dt;

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    Button btnOrder = new Button();
                //    btnOrder.BackgroundImage = global::SmartShelfUI.Properties.Resources.按钮1;
                //    btnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                //    btnOrder.FlatAppearance.BorderSize = 0;
                //    btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                //    btnOrder.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //    btnOrder.ForeColor = System.Drawing.Color.White;
                //    btnOrder.Location = new System.Drawing.Point(3, 3 + 55 * i);
                //    btnOrder.Size = new System.Drawing.Size(550, 55);
                //    btnOrder.Text = dt.Rows[i]["PartNum"].ToString() + "    "
                //        + dt.Rows[i]["ToolName"].ToString() + "    "
                //        //+ dt.Rows[i]["ToolBasicNum"].ToString() + "    "
                //        + dt.Rows[i]["WorkTime"].ToString() + "    "
                //        + dt.Rows[i]["ToolLevel"].ToString();
                //    btnOrder.Tag = dt.Rows[i]["Id"].ToString();
                //    btnOrder.UseVisualStyleBackColor = true;
                //    btnOrder.Click += btnOpenDoor_Click;
                //    panel_CAM.Controls.Add(btnOrder);
                //}
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

            }
        }
    }
}
