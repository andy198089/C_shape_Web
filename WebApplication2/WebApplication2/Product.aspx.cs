using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
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
            List<ImageButton> imageButtons = new List<ImageButton>() { ImageButton1, ImageButton2, ImageButton3, ImageButton4, ImageButton5, ImageButton6, 
                ImageButton7, ImageButton8, ImageButton9 , ImageButton10, ImageButton11, ImageButton12 };
            //product_information_list
            List<product_inf> product_infs = new List<product_inf>();

            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            string product_list = "SPA淋浴柱$";

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
                    product_infs.Add(product_inf);                    
                }
            }
            sqlConnection.Close();

            //將資訊塞入
            for(int i = 0; i < 12;i++)
            {
                if(i >= product_infs.Count)
                {
                    labels[i].Text = "";
                    imageButtons[i].ImageUrl = "";
                }
                else
                {
                    labels[i].Text = product_infs[i].product_type+ " "+ product_infs[i].product_name;
                    imageButtons[i].ImageUrl = $"~/product_pic/{product_infs[i].product_type}_2.jpg";
                }
            }
        }
    }
}