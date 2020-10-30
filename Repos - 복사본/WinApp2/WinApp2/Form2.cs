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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string sRet;

        private void button1_Click(object sender, EventArgs e)
        {
            sRet = comboBox1.Text + " " +
                       comboBox2.Text + " " +
                       comboBox3.Text + " " +
                       comboBox4.Text + " " +
                       comboBox5.Text; // sRet를 텍스트 창에 뜨게 하려면 ok버튼 속성을 dialogresult 값을 ok로 바꾸어주어야한다

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
