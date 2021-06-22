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
    public partial class item_overview : System.Web.UI.Page
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
            int orderID = int.Parse(Request["orderid"]);

            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            string sql_str = "select * from Orders where id = '" + orderID + "'";

            SqlCommand sqlCommand = new SqlCommand(sql_str, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                if (sqlDataReader.Read())
                {
                    buystr += sqlDataReader["buy"].ToString().Replace("\"", "");

                }
            }

            sqlConnection.Close();

            string sql_data2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            SqlConnection sqlConnection2 = new SqlConnection(sql_data2);

            string[] buyList = buystr.Split(',');

            int count = 0;
            foreach (var buy in buyList)
            {
                count++;
                if (count % 3 == 1)
                {
                    tableName = buy;
                }
                if (count % 3 == 2)
                {
                    string sqlstr_products = "select * from " + tableName + " where ID = " + buy;

                    SqlCommand sqlCommand2 = new SqlCommand(sqlstr_products, sqlConnection2);

                    sqlConnection2.Open();

                    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();

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
                    sqlConnection2.Close();
                }
                if (count % 3 == 0)
                {
                    sum = Convert.ToInt32(buy);
                }
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("系列");
            dt.Columns.Add("型號");
            dt.Columns.Add("名稱");
            dt.Columns.Add("規格");
            dt.Columns.Add("尺寸");
            dt.Columns.Add("數量");
            dt.Columns.Add("售價");
            DataRow dr = dt.NewRow();

            dr["ID"] = itemID;
            dr["系列"] = tableName.Replace("$", "");
            dr["型號"] = model;
            dr["名稱"] = productName;
            dr["規格"] = size;
            dr["尺寸"] = large;
            dr["數量"] = sum;
            dr["售價"] = price;
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}