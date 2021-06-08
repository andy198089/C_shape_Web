using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Product8 : System.Web.UI.Page
    {
        public int PageCount { get; set; }
        public class product_inf
        {
            public int ID { get; set; }
            public string product_type { get; set; }
            public string product_name { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //label_list
            List<Label> labels = new List<Label>() { Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12 };

            //imgae_list
            List<Image> Images = new List<Image>() { Image1, Image2, Image3, Image4, Image5, Image6,
                Image7, Image8, Image9 , Image10, Image11, Image12 };
            //product_information_list
            List<product_inf> product_infs = new List<product_inf>();

            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            string product_list = "銅#不銹鋼球塞#逆止系列$";

            string sqlstr = $"select * from {product_list}";

            SqlCommand sqlCommand = new SqlCommand(sqlstr, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    product_inf product_inf = new product_inf
                    {
                        ID = (int)sqlDataReader["ID"],                        
                        product_type = sqlDataReader["型號"].ToString(),
                        product_name = sqlDataReader["名稱"].ToString(),
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
            sqlConnection.Close();

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

            int j = 12 * (pageIndex-1);
            //將資訊塞入
            for (int i = 0; i < 12; i++)
            {
                if (i >= product_infs.Count - j)
                {
                    labels[i].Text = "";
                    Images[i].ImageUrl = "";
                }
                else
                {
                    labels[i].Text = product_infs[i + j].product_type + " " + product_infs[i + j].product_name;
                    Images[i].ImageUrl = $"~/product_pic/{product_infs[i + j].product_type}_2.jpg";
                }
            }
        }
    }
}