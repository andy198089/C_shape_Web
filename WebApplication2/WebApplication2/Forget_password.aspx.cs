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
    public partial class Forget_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["account"] != "" && Request.Form["userName"] != "" && Request.Form["email"] != "")
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                string sqlstr_accountCheck = "select * from Users where account ='" + Request.Form["account"] + "'";

                SqlCommand sqlCommand = new SqlCommand(sqlstr_accountCheck, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    if (sqlDataReader.Read())
                    {
                        if (Request.Form["userName"] == sqlDataReader["userName"].ToString() && Request.Form["email"] == sqlDataReader["email"].ToString())
                        {
                            Session["ID"] = sqlDataReader["id"];
                            Response.Redirect("Change_password.aspx");
                        }
                        else if (Request.Form["userName"] != sqlDataReader["userName"].ToString())
                        {
                            Label2.Text = "使用者名稱輸入錯誤!";
                        }
                        else
                        {
                            Label3.Text = "信箱輸入錯誤!";
                        }
                    }
                }
                else
                {
                    Label1.Text = "帳號輸入錯誤!";
                }
            }
        }
    }
}