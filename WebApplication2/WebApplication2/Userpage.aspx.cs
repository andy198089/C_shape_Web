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
        public int count = 0;
        public string tableName = "";
        public string tableName_out = "";
        public string productString = "";
        public string size = "";
        public string done = "";
        public string sum = "";
        public List<string> date = new List<string>() { "請選擇" };
        public string buystr = "";
        public int Idx;
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
                while (sqlDataReader2.Read())
                {
                    date.Add(sqlDataReader2["initdate"].ToString().Replace(" 上午 12:00:00", ""));
                }
                sqlConnection.Close();
            }
            if (!IsPostBack) //防止重複刷新==>造成只能選取第一項
            {
                //商品系列填入下拉式選單
                this.DropDownList1.DataSource = date;
                this.DropDownList1.DataBind();
                this.DropDownList1.Style["display"] = "none"; //將舊樣式的隱藏起來
            }
        }
        public void BindGrid(int idx)
        {

            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            string sqlstr_dropbox = "select * from Orders where initdate = '" + date[idx] + "'";

            SqlCommand sqlCommand4 = new SqlCommand(sqlstr_dropbox, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader3 = sqlCommand4.ExecuteReader();

            if (sqlDataReader3.HasRows)
            {
                if (sqlDataReader3.Read())
                {
                    buystr += sqlDataReader3["buy"].ToString().Replace("\"", "");
                    if (sqlDataReader3["done"].ToString() == "0")
                    {
                        done = "訂單處理中";
                    }
                    else
                    {
                        done = "訂單完成";
                    }
                }
            }
            sqlConnection.Close();

            string sql_data2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            SqlConnection sqlConnection2 = new SqlConnection(sql_data2);

            string[] buyList = buystr.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("系列");
            dt.Columns.Add("名稱");
            dt.Columns.Add("規格");
            dt.Columns.Add("數量");
            dt.Columns.Add("進度");
            foreach (var buy in buyList)
            {                
                count++;
                DataRow dr = dt.NewRow();
                if (count % 3 == 1)
                {
                    tableName = buy;
                    tableName_out = buy.Replace("$", "");
                }
                else if (count % 3 == 2)
                {
                    string sqlstr_products = "select * from " + tableName + " where ID = " + buy;

                    SqlCommand sqlCommand3 = new SqlCommand(sqlstr_products, sqlConnection2);

                    sqlConnection2.Open();

                    SqlDataReader sqlDataReader4 = sqlCommand3.ExecuteReader();

                    if (sqlDataReader4.HasRows)
                    {
                        if (sqlDataReader4.Read())
                        {
                            productString = sqlDataReader4["名稱"].ToString();
                            if (sqlDataReader4["規格"] == null || sqlDataReader4["規格"] == "")
                            {
                                size = "無";
                            }
                            else
                            {
                                size = sqlDataReader4["規格"].ToString();
                            }
                        }
                    }
                    sqlConnection2.Close();
                }
                else if (count % 3 == 0)
                {
                    sum = buy;
                    dr["名稱"] = productString;
                    dr["規格"] = size;
                    dr["數量"] = sum;
                    dr["系列"] = tableName_out;
                    dr["進度"] = done;
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DropDownList1.SelectedIndex; //取得對應的index
            if (idx == 0)
            {
                Response.Write("<script>alert('請選擇正確日期');</script>");
            }
            else
            {
                Idx = idx;
                BindGrid(idx);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserModify.aspx");
        }
    }
}