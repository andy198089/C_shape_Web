using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace C_shape_Web
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logined"] == "login")
            {
                Response.Write("<script>alert('已有會員');location.href='index.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["account"] != "")
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);           

                string sqlstr_accountCheck = "select * from Users where acount ='" + Request.Form["account"] + "'";

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
                        string sqlstr = $"insert into [Users](acount,password,userName) values (@acount,@password,@userName)";

                        SqlCommand sqlcommand2 = new SqlCommand(sqlstr, sqlConnection);

                        sqlcommand2.Parameters.Add("@acount", SqlDbType.NVarChar);
                        sqlcommand2.Parameters["@acount"].Value = Request.Form["account"];

                        sqlcommand2.Parameters.Add("@password", SqlDbType.NVarChar);
                        sqlcommand2.Parameters["@password"].Value = Request.Form["password"];

                        sqlcommand2.Parameters.Add("@userName", SqlDbType.NVarChar);
                        sqlcommand2.Parameters["@userName"].Value = Request.Form["userName"];

                        sqlcommand2.ExecuteNonQuery();
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