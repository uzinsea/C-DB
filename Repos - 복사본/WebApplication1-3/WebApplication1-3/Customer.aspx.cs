using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_3
{
    
    public partial class Coustormer : System.Web.UI.Page
    {SqlConnection sConn = new SqlConnection();
    SqlCommand sCmd = new SqlCommand();
    string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Source\Repos\Mytable.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;
        }

        protected void btnSign_Click(object sender, EventArgs e)
        {
            try {
            string id = tbId.Text;
            string pwd = tbPwd.Text;
            string name = tbName.Text;
            string birth = tbBirth.Text;
            string sex = rbSex.SelectedValue.ToString();
            string phone = tbPhone.Text;

            sCmd.CommandText = $"insert into Coutomnew values ('{id}','{pwd}','{name}','{birth}','{sex}','{phone}')";

            sCmd.ExecuteNonQuery();
                Label1.Text = "";
            }
            catch
            {

            }

        }
    }
}