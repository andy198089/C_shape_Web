using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace WebApplication2
{
    public partial class Product : System.Web.UI.Page
    {
        public int PageClass { get; set; }
        public int PageCount { get; set; }
        public int NowPage { get; set; }

        //dataname_list(HTML用)
        public List<string> datanames = new List<string>() { };
        public class product_inf
        {
            public int ID { get; set; }
            public string product_type { get; set; }
            public string product_name { get; set; }
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            //dataname_list(內部用)
            List<string> datanames_1 = new List<string>() { };

            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            //抓取所有資料表名稱
            string sql_dataname = "select Table_name from INFORMATION_SCHEMA.TABLES order by Table_name";

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            SqlCommand sqlCommand = new SqlCommand(sql_dataname, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    datanames.Add(sqlDataReader["Table_name"].ToString().Replace("$", "").Replace("'", "").Replace("#", "。"));
                    datanames_1.Add(sqlDataReader["Table_name"].ToString());
                }
            }
            sqlConnection.Close();

            //讀取商品

            //判斷選取哪個系列
            string product_class;
            int pageclass = int.Parse(Request["pageclass"] ?? "1"); //默認為1
            PageClass = pageclass; // 給分頁用
            product_class = datanames_1[pageclass-1];

            //label_list
            List<Label> labels = new List<Label>() { Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12 };

            //imgae_list
            List<Image> Images = new List<Image>() { Image1, Image2, Image3, Image4, Image5, Image6,
                Image7, Image8, Image9 , Image10, Image11, Image12 };

            //div_id_list
            List<HtmlGenericControl> div_ids = new List<HtmlGenericControl>() { product_div1, product_div2, product_div3, product_div4, product_div5, product_div6, product_div7, 
                product_div8, product_div9, product_div10, product_div11, product_div12,};

            //product_information_list
            List<product_inf> product_infs = new List<product_inf>();

            SqlConnection sqlConnection_2 = new SqlConnection(sql_data);

            string product_list = $"[{product_class}]";

            string sqlstr = $"select * from {product_list}";

            SqlCommand sqlCommand_2 = new SqlCommand(sqlstr, sqlConnection_2);

            sqlConnection_2.Open();

            SqlDataReader sqlDataReader_2 = sqlCommand_2.ExecuteReader();

            if (sqlDataReader_2.HasRows)
            {
                while (sqlDataReader_2.Read())
                {
                    product_inf product_inf = new product_inf
                    {
                        ID = (int)sqlDataReader_2["ID"],                        
                        product_type = sqlDataReader_2["型號"].ToString(),
                        product_name = sqlDataReader_2["名稱"].ToString(),
                    };
                    if (product_infs.Count == 0)
                    {
                        product_infs.Add(product_inf);
                    }
                    else
                    {
                        //排除型號與名稱一樣的產品
                        if (product_inf.product_type == product_infs[product_infs.Count-1].product_type && product_inf.product_name == product_infs[product_infs.Count - 1].product_name)
                        {
                            continue;
                        }
                        else
                        {
                            product_infs.Add(product_inf);
                        }
                    }
                }
            }
            sqlConnection_2.Close();

            //分頁設置
            if (product_infs.Count % 12 == 0)
            {
                PageCount = product_infs.Count / 12;
            }
            else
            {
                PageCount = (product_infs.Count / 12) + 1;
            }
            //取得頁碼參數
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1"); //默認為1
            NowPage = pageIndex;

            int j = 12 * (pageIndex-1);
            //將資訊塞入
            for (int i = 0; i < 12;i++)
            {
                if(i >= product_infs.Count-j)
                {
                    labels[i].Text = "";
                    Images[i].ImageUrl = "";
                    div_ids[i].Style["display"] = "none"; //將空的商品div隱藏
                }
                else
                {
                    labels[i].Text = product_infs[i+j].product_type+ " "+ product_infs[i+j].product_name;
                    Images[i].ImageUrl = $"~/product_pic/{product_infs[i+j].product_type}_2.jpg";
                }
            }
        }
    }
}