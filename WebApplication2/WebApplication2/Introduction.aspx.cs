using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Introduction : System.Web.UI.Page
    {
        public List<string> datanames = new List<string>() { };
        //產品細項list
        List<product_inf> product_infs = new List<product_inf>();
        public int Price { get; set; }
        public int Idx { get; set; }
        public class product_inf
        {
            public int ID { get; set; }
            public string product_name { get; set; }
            public string product_format { get; set; }
            public string product_size { get; set; }
            public int product_price { get; set; }
            public int product_count { get; set; }
            public string product_image { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得網址資訊
            int product_class = int.Parse(Request["productclass"]);
            string product_type = Request["producttype"];

            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            //取得Class名稱
            string sql_dataname = "select Table_name from INFORMATION_SCHEMA.TABLES order by Table_name";
            System.Data.SqlClient.SqlConnection sqlConnection = new SqlConnection(sql_data);

            SqlCommand sqlCommand = new SqlCommand(sql_dataname, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    datanames.Add(sqlDataReader["Table_name"].ToString());
                }
            }
            sqlConnection.Close();

            //取得型號與對應的產品名稱
            string sql_select = $"select [ID],[名稱],[規格],[尺寸],[售價],[數量],[image_2] from [{datanames[product_class-1]}] where 型號='{product_type}'";
            SqlCommand sqlCommand_2 = new SqlCommand(sql_select, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader_2 = sqlCommand_2.ExecuteReader();
                        
            if (sqlDataReader_2.HasRows)
            {
                while (sqlDataReader_2.Read())
                {
                    product_inf product_inf = new product_inf
                    {
                        ID = (int)sqlDataReader_2["ID"],
                        product_name = sqlDataReader_2["名稱"].ToString(),
                        product_format = sqlDataReader_2["規格"].ToString(),
                        product_size = sqlDataReader_2["尺寸"].ToString(),
                        product_price = (int)sqlDataReader_2["售價"],
                        product_count = (int)sqlDataReader_2["數量"],
                        product_image = sqlDataReader_2["image_2"].ToString(),
                    };
                    product_infs.Add(product_inf);
                }
            }
            sqlConnection.Close();

            Label1.Text = product_type+"  "+product_infs[0].product_name;
            Image1.ImageUrl = $"~/product_pic/{product_infs[0].product_image}";

            //產生選項資料
            List<string> product_list = new List<string>();
            foreach(var i in product_infs)
            {
                string product_str = "";
                if (i.product_format == "")
                {
                    product_str += "規格：(無)";
                }
                else
                {
                    product_str += $"規格：{i.product_format}";
                }
                if(i.product_size == "")
                {
                    product_str += "\t尺寸：(無)";
                }
                else
                {
                    product_str += $"\t尺寸：{i.product_size}";
                }
                
                product_list.Add(product_str);
            }

            //填入資料
            if (!IsPostBack) //防止重複刷新==>造成只能選取第一項
            {
                this.RadioButtonList1.DataSource = product_list;
                this.RadioButtonList1.DataBind();
            }
        }
        //取得RadioButtonList1的值
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = RadioButtonList1.SelectedIndex;
            Idx = idx;
            Label6.Text = product_infs[idx].product_price.ToString();
            Label8.Text = product_infs[idx].product_count.ToString();
            Session["product_id"] = product_infs[Idx].ID.ToString();
            Session["product_count"] = product_infs[idx].product_count;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex == -1)
            {
                Response.Write("<script>alert('請選擇正確的商品')</script>");
            }
            else if (TextBox1.Text == "")
            {
                Response.Write("<script>alert('請輸入要購買的數量')</script>");
            }
            else if (int.Parse(TextBox1.Text) > (int)Session["product_count"])
            {
                Response.Write("<script>alert('超過所能購買的數量!!請重新輸入')</script>");
            }
            else
            {
                int product_class = int.Parse(Request["productclass"]);
                string buy_product = datanames[product_class - 1] + "," + Session["product_id"] + "," + TextBox1.Text + ",";
                Session["buyorder"] += buy_product;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/shopping_cart.aspx");
        }
    }
}