using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
<<<<<<< HEAD
<<<<<<< Updated upstream
    public partial class Product : System.Web.UI.Page
    {
        public int PageCount { get; set; }
        public int NowPage { get; set; }
=======
    public partial class WebForm2 : System.Web.UI.Page
    {
>>>>>>> Stashed changes
=======
    public partial class Product : System.Web.UI.Page
    {
        public int PageCount { get; set; }
        public int NowPage { get; set; }
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
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
<<<<<<< HEAD
<<<<<<< Updated upstream
            List<Image> Images = new List<Image>() { Image1, Image2, Image3, Image4, Image5, Image6,
                Image7, Image8, Image9 , Image10, Image11, Image12 };
=======
            List<ImageButton> imageButtons = new List<ImageButton>() { ImageButton1, ImageButton2, ImageButton3, ImageButton4, ImageButton5, ImageButton6, 
                ImageButton7, ImageButton8, ImageButton9 , ImageButton10, ImageButton11, ImageButton12 };
>>>>>>> Stashed changes
=======
            List<Image> Images = new List<Image>() { Image1, Image2, Image3, Image4, Image5, Image6,
                Image7, Image8, Image9 , Image10, Image11, Image12 };
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
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
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
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
<<<<<<< HEAD
=======
                    product_infs.Add(product_inf);                    
>>>>>>> Stashed changes
=======
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
                }
            }
            sqlConnection.Close();

<<<<<<< HEAD
<<<<<<< Updated upstream
=======
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
            //分頁設置
            if(product_infs.Count % 12 == 0)
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
<<<<<<< HEAD
            //將資訊塞入
            for (int i = 0; i < 12;i++)
            {
                if(i >= product_infs.Count-j)
                {
                    labels[i].Text = "";
                    Images[i].ImageUrl = "";
                }
                else
                {
                    labels[i].Text = product_infs[i+j].product_type+ " "+ product_infs[i+j].product_name;
                    Images[i].ImageUrl = $"~/product_pic/{product_infs[i+j].product_type}_2.jpg";
=======
=======
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
            //將資訊塞入
            for (int i = 0; i < 12;i++)
            {
                if(i >= product_infs.Count-j)
                {
                    labels[i].Text = "";
                    Images[i].ImageUrl = "";
                }
                else
                {
<<<<<<< HEAD
                    labels[i].Text = product_infs[i].product_type+ " "+ product_infs[i].product_name;
                    imageButtons[i].ImageUrl = $"~/product_pic/{product_infs[i].product_type}_2.jpg";
>>>>>>> Stashed changes
=======
                    labels[i].Text = product_infs[i+j].product_type+ " "+ product_infs[i+j].product_name;
                    Images[i].ImageUrl = $"~/product_pic/{product_infs[i+j].product_type}_2.jpg";
>>>>>>> 2efcb562025d4e8f6649e146e45494bbc45b2805
                }
            }
        }
    }
}