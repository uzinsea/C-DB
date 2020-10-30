using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp2
{
    public partial class frmGettable : Form
    {
        public frmGettable()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
