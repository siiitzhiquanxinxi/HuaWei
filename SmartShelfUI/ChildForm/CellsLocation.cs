using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public List<string> lstSelected;

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
                        b.Location = new Point(10 + 60 * i, 10 + 60 * j);
                        b.Size = new Size(60, 60);
                        b.Text = x.ToString() + "-" + y.ToString();
                        b.BackColor = SystemColors.ControlDark;
                        foreach (string item in lstSelected)
                        {
                            if (item == x.ToString() + "-" + y.ToString())
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
            byte[] result = new byte[16];
            int rLength = spCom.Read(result, 0, result.Length);
            if (rLength >= 1)
            {
                if (true)
                {
                    string barcode = result.ToString();
                    List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("BarCode = '" + barcode + "'");
                    if (lstmodel != null && lstmodel.Count > 0)
                    {
                        foreach (Control item in panel_Cells.Controls)
                        {
                            if (item is Button)
                            {
                                Button b = item as Button;
                                if (b.Tag.ToString() == barcode)
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        b.BackColor = Color.Green;
                                        return;
                                    });
                                }
                            }
                        }
                    }

                }

            }
        }
    }
}
