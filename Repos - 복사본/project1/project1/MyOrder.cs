using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class MyOrder : Form
    {
        public MyOrder()
        {
            InitializeComponent();
        }
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Source\Repos\Icecream31.mdf;Integrated Security=True;Connect Timeout=30";


        private void MyOrder_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;

        }
        private void btnMyorder_Click(object sender, EventArgs e)
        {
           
            Close();
        }

        private void btnHomeLogout_Click(object sender, EventArgs e)
        {
            string id = tbMyID.Text;
            sCmd.CommandText = $"delete OrderList where id = '{id}'";
            sCmd.ExecuteNonQuery();
        }
    }
}
