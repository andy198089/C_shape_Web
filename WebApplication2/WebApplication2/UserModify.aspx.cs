using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public partial class UserModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "定期更換密碼以確保帳戶安全!";
            Label6.Text = "";
            Label7.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Form["password"] != "" && Request.Form["password"] == Request.Form["password2"])
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                string sqlstr = "select * from Users where id = '" + Session["ID"] + "'";

                SqlCommand sqlCommand = new SqlCommand(sqlstr, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    if (sqlDataReader.Read())
                    {
                        if (Request.Form["password"] == sqlDataReader["password"].ToString())
                        {
                            Label6.Text = "新密碼不可與舊密碼相同";
                            sqlConnection.Close();
                        }
                        else
                        {
                            sqlConnection.Close();

                            sqlConnection.Open();

                            sqlstr = "update [Users] set password = @password where id = '" + Session["ID"] + "'";

                            SqlCommand sqlCommand2 = new SqlCommand(sqlstr, sqlConnection);

                            sqlCommand2.Parameters.Add("@password", SqlDbType.NVarChar);
                            sqlCommand2.Parameters["@password"].Value = Request.Form["password"];

                            sqlCommand2.ExecuteNonQuery();
                            sqlConnection.Close();
                            Response.Write("<script>alert('密碼修改成功');location.href='Userpage.aspx';</script>");
                        }
                    }
                }
            }
            else
            {
                if (Request.Form["password"] == "")
                {
                    Label6.Text = "請輸入密碼";
                }
                else
                {
                    Label7.Text = "兩次密碼輸入不相同";
                }
            }
        }
    }
}