using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class Userpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logined"] == "login")
            {
                Label1.Text = "HI! " + Session["userName"];
                Label6.Text = Session["userName"].ToString();

                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                string sqlstr_accountCheck = "select * from Users where id ='" + Session["ID"] + "'";

                SqlCommand sqlCommand = new SqlCommand(sqlstr_accountCheck, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    if (sqlDataReader.Read())
                    {
                        Label7.Text = sqlDataReader["account"].ToString();
                        string sql_password = sqlDataReader["password"].ToString();

                        for (int i = 0; i < sql_password.Length; i++)
                        {
                            Label8.Text += "*";
                        }
                    }
                }

                sqlConnection.Close();
            }
            else
            {
                Response.Write("<script>alert('尚未登入，即將跳轉至登入頁面...');location.href='Login.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserModify.aspx");
        }
    }
}