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
    public partial class AddProduct : System.Web.UI.Page
    {
        public List<string> datanames = new List<string>() { "請選擇" };

        //dataname_list(內部用)
        public List<string> datanames_1 = new List<string>() { };
        public string Img_1 { get; set; }
        public string Img_2 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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
            datanames.Add("新增商品種類...");

            if (!IsPostBack) //防止重複刷新==>造成只能選取第一項
            {
                //商品系列填入下拉式選單
                this.DropDownList1.DataSource = datanames;
                this.DropDownList1.DataBind();
                this.DropDownList1.Style["display"] = "none"; //將舊樣式的隱藏起來
            }

            //新增商品種類的Textbox和buttom
            TextBox1.Attributes.Add("style", "font-size:Large;color:#666666");
            TextBox1.Visible = false;
            Button1.Visible = false;
            Label14.Visible = false;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DropDownList1.SelectedIndex - 1; //取得對應的index
            if (idx == (datanames.Count - 2))
            {
                TextBox1.Visible = true;
                Button1.Visible = true;
                Label14.Visible = true;
            }
            Session["Idx"] = idx;

        }

        protected void Create_Table(object sender, EventArgs e)
        {
            //設定資料表-設計
            string table_name = TextBox1.Text;
            string sqlStr = "create table ";
            sqlStr += table_name + "( ";
            sqlStr += "ID int identity(1,1) primary key,"; //ID
            sqlStr += "型號 nvarchar(255),";  //型號
            sqlStr += "名稱 nvarchar(255),";  //名稱
            sqlStr += "規格 nvarchar(255),";  //規格
            sqlStr += "尺寸 nvarchar(255),";  //尺寸
            sqlStr += "牌價 int,";  //牌價
            sqlStr += "售價 int,";  //售價
            sqlStr += "數量 int,";  //數量
            sqlStr += "image_1 nvarchar(255),";  //image_1的URL
            sqlStr += "image_2 nvarchar(255),";  //image_2的URL
            sqlStr += " )";

            //連線資料庫並創建資料表
            try
            {
                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(sql_data);
                SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                Response.Write("<script>window.alert('創建成功!!');location.href='AddProduct.aspx';</script>");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Response.Write("<script>alert('創建失敗!!已有相同的種類了!!');</script>");
            }
        }

        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/product_pic/");
            if (this.FileUpload1.HasFile)
            {
                string fileException = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileException.Equals(".jpg") || fileException.Equals(".png") || fileException.Equals(".jpeg"))
                {
                    string new_name = TextBox2.Text;
                    string pic_name = "";
                    if (fileException.Equals(".jpg"))
                    {
                        pic_name = new_name + "_1.jpg";//這是存到伺服器上的虛擬路徑
                    }
                    else if (fileException.Equals(".png"))
                    {
                        pic_name = new_name + "_1.png";
                    }
                    else if (fileException.Equals(".jpeg"))
                    {
                        pic_name = new_name + "_1.jpeg";
                    }
                    //資料庫存路徑
                    Session["Img_1"] = pic_name;

                    string virpath = path + pic_name;
                    //string mappath = Server.MapPath(virpath); //轉換成伺服器上的物理路徑
                    //this.FileUpload1.SaveAs(mappath);
                    this.FileUpload1.SaveAs(virpath);
                    ShowImage_1.ImageUrl = $"~/product_pic/{pic_name}";
                    ShowImage_1.Height = 200;
                    ShowImage_1.Width = 150;
                    Response.Write("<script>alert('上傳成功!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('上傳失敗!僅支持JPG、PNG、JPEG格式的圖片');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('請選擇文件!');</script>");
            }
        }

        protected void btnUpload_Click2(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/product_pic/");
            if (this.FileUpload2.HasFile)
            {
                string fileException = System.IO.Path.GetExtension(FileUpload2.FileName);

                if (fileException.Equals(".jpg") || fileException.Equals(".png") || fileException.Equals(".jpeg"))
                {
                    string new_name = TextBox2.Text;
                    string pic_name_2 = "";
                    if (fileException.Equals(".jpg"))
                    {
                        pic_name_2 = new_name + "_2.jpg";//這是存到伺服器上的虛擬路徑
                    }
                    else if (fileException.Equals(".png"))
                    {
                        pic_name_2 = new_name + "_2.png";
                    }
                    else if (fileException.Equals(".jpeg"))
                    {
                        pic_name_2 = new_name + "_2.jpeg";
                    }
                    //資料庫存路徑
                    Session["Img_2"] = pic_name_2;

                    string virpath_2 = path + pic_name_2;
                    //string mappath = Server.MapPath(virpath_2); //轉換成伺服器上的物理路徑
                    //this.FileUpload1.SaveAs(mappath_2);
                    this.FileUpload1.SaveAs(virpath_2);
                    ShowImage_2.ImageUrl = $"~/product_pic/{pic_name_2}";
                    ShowImage_2.Height = 200;
                    ShowImage_2.Width = 150;
                    Response.Write("<script>alert('上傳成功!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('上傳失敗!僅支持JPG、PNG、JPEG格式的圖片');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('請選擇文件!');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(sql_data);

            if (Session["Idx"] == null || (int)Session["Idx"] == 0 || (int)Session["Idx"] == datanames_1.Count)
            {
                Response.Write("<script>alert('尚未選擇正確的產品類別!!');</script>");
            }
            else
            {
                int Idx = (int)Session["Idx"];
                string product_class = datanames_1[Idx];

                //確認是否已有該商品
                string product_list = $"[{product_class}]";
                string sqlstr;

                if (TextBox4.Text == "" && TextBox5.Text=="")
                {
                    sqlstr = $"select * from {product_list} where \"型號\"=\'{TextBox2.Text}'";
                }
                else if (TextBox4.Text == "")
                {
                    sqlstr = $"select * from {product_list} where \"型號\"=\'{TextBox2.Text}' and \"尺寸\"='{TextBox5.Text}'";
                }
                else if (TextBox5.Text == "")
                {
                    sqlstr = $"select * from {product_list} where \"型號\"=\'{TextBox2.Text}' and \"規格\"='{TextBox4.Text}'";
                }
                else
                {
                    sqlstr = $"select * from {product_list} where \"型號\"=\'{TextBox2.Text}' and \"規格\"='{TextBox4.Text}' and \"尺寸\"='{TextBox5.Text}'";
                }                       

                SqlCommand sqlCommand = new SqlCommand(sqlstr, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    sqlConnection.Close();
                    Response.Write("<script>alert('已有該產品!!');</script>");
                }
                else
                {
                    sqlConnection.Close();
                    //無該產品 => 可新增
                    if (TextBox6.Text == "")
                    {
                        TextBox6.Text = "0";
                    }
                    if (TextBox7.Text == "")
                    {
                        TextBox7.Text = "0";
                    }
                    if (TextBox8.Text == "")
                    {
                        TextBox8.Text = "0";
                    }
                    if(Session["Img_1"] == null)
                    {
                        Session["Img_1"] = "";
                    }
                    if (Session["Img_2"] == null)
                    {
                        Session["Img_2"] = "";
                    }
                    Img_1 = Session["Img_1"].ToString();
                    Img_2 = Session["Img_2"].ToString();
                    string setsql = $"insert into [{product_class}](型號, 名稱, 規格, 尺寸, 牌價, 售價, 數量, image_1, image_2) values('{TextBox2.Text}',N'{TextBox3.Text}',N'{TextBox4.Text}',N'{TextBox5.Text}','{int.Parse(TextBox6.Text)}','{int.Parse(TextBox7.Text)}','{int.Parse(TextBox8.Text)}','{Img_1}','{Img_2}')";

                    SqlCommand Command = new SqlCommand(setsql, sqlConnection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);//從Command取得資料存入dataAdapter

                    DataSet dataset = new DataSet();//創一個dataset的記憶體資料集

                    dataAdapter.Fill(dataset);//將dataAdapter資料存入dataset

                    Response.Write("<script>alert('新增成功!');</script>");

                }
                //將TextBox清空
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                ShowImage_1.ImageUrl = "";
                ShowImage_2.ImageUrl = "";

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagerPage.aspx");
        }
    }
}