using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bbb = new byte[8];
            bbb[0] = 0x70;
            bbb[1] = 0xAD;
            bbb[2] = 0xE2;
            bbb[3] = 0x2B;
            bbb[4] = 0x14;
            bbb[5] = 0x00;
            bbb[6] = 0x00;
            bbb[7] = 0x00;
            textBox1.Text = bbb[0].ToString("x2");

        }
    }
}
