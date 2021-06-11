using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logined"] == "login")
            {
<<<<<<< Updated upstream
                Response.Write("<script>alert('你已經登入過了');location.href='Home.aspx';</script>");
=======
                //主頁完成後要改連結
                Response.Write("<script>alert('你已經登入過了');location.href='Signup.aspx';</script>");
>>>>>>> Stashed changes
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["account"] != null && Request.Form["password"] != null)
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                string sqlstr = "select * from Users where account ='" + Request.Form["account"] + "'";

                SqlCommand sqlCommand = new SqlCommand(sqlstr, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    if (sqlDataReader.Read())
                    {
                        if (Request.Form["password"] == sqlDataReader["password"].ToString())
                        {
                            Session["Logined"] = "login";
                            Session["ID"] = sqlDataReader["id"];
                            Session["userName"] = sqlDataReader["userName"].ToString();
<<<<<<< Updated upstream
                            Response.Redirect("Home.aspx");
=======
<<<<<<< HEAD
                            Session["ID"] = sqlDataReader["id"].ToString();
                            //主頁完成後要改連結
                            Response.Redirect("Signup.aspx");
=======
                            //主頁完成後要改連結，index.html為測試用
                            Response.Redirect("Home.aspx");
<<<<<<< HEAD
>>>>>>> 4822d0f5b00b8875435c64a09d3628540d6f50d9
=======
>>>>>>> 4822d0f5b00b8875435c64a09d3628540d6f50d9
>>>>>>> Stashed changes
                        }
                        else
                        {
                            Response.Write("<script>alert('密碼輸入錯誤');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('帳號輸入錯誤');</script>");
                }
                sqlConnection.Close();
            }
        }
    }
}