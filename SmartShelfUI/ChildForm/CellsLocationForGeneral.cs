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
    public partial class CellsLocationForGeneral : Form
    {
        public CellsLocationForGeneral()
        {
            InitializeComponent();
        }

        public DTcms.Model.w_barcode tool = null;
        public DTcms.Model.sy_shelf shelf = null;
        public DTcms.Model.sy_cabinet cabinet = null;
        private void CellsLocationForGeneral_Load(object sender, EventArgs e)
        {
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
                        if (tool.X == i + 1 && tool.Y == j + 1)
                        {
                            b.BackColor = Color.Orange;
                        }
                        b.UseVisualStyleBackColor = true;
                        panel_Cells.Controls.Add(b);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
