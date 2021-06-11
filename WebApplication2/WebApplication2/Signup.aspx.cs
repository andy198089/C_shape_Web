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
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logined"] == "login")
            {
<<<<<<< Updated upstream
                Response.Write("<script>alert('已有會員');location.href='Home.aspx';</script>");
=======
                //主頁完成後要改連結
                Response.Write("<script>alert('已有會員');location.href='index.html';</script>");
>>>>>>> Stashed changes
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["account"] != "")
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                string sqlstr_accountCheck = "select * from Users where account ='" + Request.Form["account"] + "'";

                SqlCommand sqlCommand = new SqlCommand(sqlstr_accountCheck, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Label1.Text = "帳號重複";
                    sqlConnection.Close();
                }
                else
                {
                    sqlConnection.Close();
                    if (Request.Form["password"] != "" && (Request.Form["password"] == Request.Form["password2"]) && Request.Form["userName"] != "")
                    {
                        sqlConnection.Open();
                        string sqlstr = $"insert into [Users](account,password,userName) values (@account,@password,@userName)";

                        SqlCommand sqlCommand2 = new SqlCommand(sqlstr, sqlConnection);

                        sqlCommand2.Parameters.Add("@account", SqlDbType.NVarChar);
                        sqlCommand2.Parameters["@account"].Value = Request.Form["account"];

                        sqlCommand2.Parameters.Add("@password", SqlDbType.NVarChar);
                        sqlCommand2.Parameters["@password"].Value = Request.Form["password"];

                        sqlCommand2.Parameters.Add("@userName", SqlDbType.NVarChar);
                        sqlCommand2.Parameters["@userName"].Value = Request.Form["userName"];

                        sqlCommand2.ExecuteNonQuery();                        
                        Response.Write("<script>alert('帳號註冊成功,請重新登入');location.href='Login.aspx';</script>");
                        sqlConnection.Close();
                    }
                    else
                    {
                        if (Request.Form["password"] == "")
                        {
                            Label2.Text = "密碼不可為空";
                        }

                        if (Request.Form["password"] != Request.Form["password2"])
                        {
                            Label3.Text = "請確認兩次輸入相同密碼";
                        }

                        if (Request.Form["userName"] == "")
                        {
                            Label4.Text = "使用者名稱不可為空";
                        }
                    }
                }
            }
            else
            {
                Label1.Text = "帳號不可為空";
            }
        }
    }
}