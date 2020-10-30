using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_3
{
    public partial class _Default : Page
    {
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Source\Repos\Mytable.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;
        }

        public string GetDBData(string Table, string Field, string KField , string Kvalue)
        {
            sCmd.CommandText = $"select {Field} from {Table} where {KField} = '{Kvalue}'";

            return sCmd.ExecuteScalar().ToString();
        }

       

        protected void login_Click(object sender, EventArgs e)
        {
            string sName = tbUsername.Text;
            string sPwd = tbPassword.Text;

            string s1 = GetDBData("Custom", "PWD", "Name",sName).Trim();//trim은 앞뒤에있는 공백문자를 지워줌 순수문자열만되돌려줌
            if(sPwd==s1)
                Iblcong.Text = $"{sName}님, 반갑습니다.";
            //DB에서 사용자 명 및 암호 조회해서 OK면 진행
            //아니면 회원 가입 안내 메세지,
            else  Iblcong.Text = "회원가입 정보가 없습니다";
        }

        protected void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSign_Click(object sender, EventArgs e)
        {
            Server.Transfer("Customer.aspx");
        }
    }
}