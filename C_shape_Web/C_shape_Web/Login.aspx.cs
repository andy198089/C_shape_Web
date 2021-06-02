using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace C_shape_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logined"] == "login")
            {
                Response.Write("<script>alert('你已經登入過了');location.href='index.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            if (Request.Form["account"] != null && Request.Form["password"] != null)
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                string sqlstr = "select * from Users where acount ='" + Request.Form["account"] + "'";

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
                            Session["userName"] = sqlDataReader["userName"].ToString();
                            Response.Redirect("index.aspx");
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