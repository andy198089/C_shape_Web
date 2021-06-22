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
    public partial class shopping_cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string buystr = "";
            string tableName = "";
            int itemID = 0;
            string model = "";
            string productName = "";
            string size = "";
            string large = "";
            int price = 0;
            int sum = 0;
            int row = 0;

            ViewState["submittimes"] = Convert.ToInt32(ViewState["submittimes"]) + 1;
            if (!Page.IsPostBack)
            {
                ViewState["submittimes"] = 1;
            }


            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            string[] buyList = Session["buyorder"].ToString().Split(',');

            int count = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("系列");
            dt.Columns.Add("型號");
            dt.Columns.Add("名稱");
            dt.Columns.Add("規格");
            dt.Columns.Add("尺寸");
            dt.Columns.Add("數量");
            dt.Columns.Add("售價");
            dt.Columns.Add("總價");

            foreach (var buy in buyList)
            {
                DataRow dr = dt.NewRow();
                count++;
                if (count % 3 == 1)
                {
                    tableName = buy;
                }
                if (count % 3 == 2)
                {
                    string sqlstr_products = "select * from " + tableName + " where ID = " + buy;

                    SqlCommand sqlCommand = new SqlCommand(sqlstr_products, sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();

                    if (sqlDataReader2.HasRows)
                    {
                        if (sqlDataReader2.Read())
                        {
                            itemID = Convert.ToInt32(sqlDataReader2["ID"]);
                            model = sqlDataReader2["型號"].ToString();
                            productName = sqlDataReader2["名稱"].ToString();
                            size = sqlDataReader2["規格"].ToString();
                            large = sqlDataReader2["尺寸"].ToString();
                            price = Convert.ToInt32(sqlDataReader2["售價"]);
                        }
                    }
                    sqlConnection.Close();
                }
                if (count % 3 == 0)
                {
                    sum = Convert.ToInt32(buy);
                    dr["ID"] = itemID;
                    dr["系列"] = tableName.Replace("$", "");
                    dr["型號"] = model;
                    dr["名稱"] = productName;
                    dr["規格"] = size;
                    dr["尺寸"] = large;
                    dr["數量"] = sum;
                    dr["售價"] = price;
                    dr["總價"] = sum * price;
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    row++;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            string sql_str = $"insert into[Orders](CusID, buy, done) values(@CusID, @buy, @done)";

            SqlCommand sqlCommamd = new SqlCommand(sql_str, sqlConnection);

            sqlConnection.Open();

            sqlCommamd.Parameters.Add("@CusID", SqlDbType.Int);
            sqlCommamd.Parameters["@CusID"].Value = Session["ID"];

            sqlCommamd.Parameters.Add("@buy", SqlDbType.NVarChar);
            sqlCommamd.Parameters["@buy"].Value = Session["buyorder"];

            sqlCommamd.Parameters.Add("@done", SqlDbType.Int);
            sqlCommamd.Parameters["@done"].Value = 0;

            sqlCommamd.ExecuteNonQuery();
            Response.Write("<script>alert('訂購完成');location.href='shopping_cart.aspx';</script>");
            sqlConnection.Close();

            Session["buyorder"] = "";
        }
    }
}