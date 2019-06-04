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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public delegate void FormHandle();
        public event FormHandle nextForm_pick;
        public event FormHandle nextForm_return;
        public event FormHandle nextForm_repair;
        public event FormHandle nextForm_users;
        public event FormHandle nextForm_warehouse;
        public event FormHandle nextForm_stock;
        private void btnReturn_Click(object sender, EventArgs e)
        {
            nextForm_return();
        }
        private void btnRepair_Click(object sender, EventArgs e)
        {
            nextForm_repair();
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            nextForm_users();
        }
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            nextForm_warehouse();

        }
        private void btnStock_Click(object sender, EventArgs e)
        {
            nextForm_stock();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            nextForm_pick();
        }
    }
}
