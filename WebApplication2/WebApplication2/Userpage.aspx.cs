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
            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            if (Session["Logined"] == "login")
            {
                Label1.Text = "HI! " + Session["userName"];
                Label6.Text = Session["userName"].ToString();

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

            string sqlstr_orders = "select * from Orders where CusID = '" + Session["ID"] + "'";

            SqlCommand sqlCommand2 = new SqlCommand(sqlstr_orders, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();

            if (sqlDataReader2.HasRows)
            {
                if (sqlDataReader2.Read())
                {
                    int count = 0;
                    string tableName = "";
                    string tableName_out = "";
                    string productString = "";
                    string done = "";
                    string sum = "";

                    if (Convert.ToInt32(sqlDataReader2["done"]) == 1)
                    {
                        done = "訂單完成";
                    }
                    else
                    {
                        done = "訂單處理中";
                    }

                    string buystr = sqlDataReader2["buy"].ToString().Replace("\"", "");
                    sqlConnection.Close();

                    string sql_data2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

                    SqlConnection sqlConnection2 = new SqlConnection(sql_data2);

                    string[] buyList = buystr.Split(',');
                    foreach (var buy in buyList)
                    {
                        count++;
                        if (count % 3 == 1)
                        {
                            tableName = buy;
                            tableName_out = "系列:" + buy + "&nbsp";
                            Label10.Text += tableName_out;
                        }
                        else if (count % 3 == 2)
                        {
                            string sqlstr_products = "select * from " + tableName + " where ID = '" + buy + "'";

                            SqlCommand sqlCommand3 = new SqlCommand(sqlstr_products, sqlConnection2);

                            sqlConnection2.Open();

                            SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();

                            if (sqlDataReader3.HasRows)
                            {
                                if (sqlDataReader3.Read())
                                {
                                    if (sqlDataReader3["規格"] == "")
                                    {
                                        productString = "名稱:" + sqlDataReader3["名稱"].ToString() + "規格:" + sqlDataReader3["規格"].ToString() + "&nbsp";
                                    }
                                    else
                                    {
                                        productString = "名稱:" + sqlDataReader3["名稱"].ToString() + "&nbsp";
                                    }
                                }
                            }
                            Label10.Text += productString + "&nbsp";

                            sqlConnection2.Close();
                        }
                        else if (count % 3 == 0)
                        {
                            sum = "數量:" + buy;
                            Label10.Text += sum + "&nbsp" + "&nbsp" + "&nbsp" + done + "<br>";
                        }
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserModify.aspx");
        }
    }
}