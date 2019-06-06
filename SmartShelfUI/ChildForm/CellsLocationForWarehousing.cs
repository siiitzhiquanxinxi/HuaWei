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
    public partial class CellsLocationForWarehousing : Form
    {
        public CellsLocationForWarehousing()
        {
            InitializeComponent();
        }

        public int ShelfID;
        public string selectedXY;
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

        private void CellsLocationForWarehousing_Load(object sender, EventArgs e)
        {

        }

    }
}
