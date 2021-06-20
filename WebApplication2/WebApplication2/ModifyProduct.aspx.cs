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
    public partial class ModifyProduct : System.Web.UI.Page
    {
        public List<string> datanames = new List<string>() { "請選擇" };

        //dataname_list(內部用)
        public List<string> datanames_1 = new List<string>() { };
        public string Img_1 { get; set; }
        public string Img_2 { get; set; }
        public string Org_type { get; set; }
        public void BindGrid(int idx, int id)  //商品呈現於Grid表格中
        {
            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;
            SqlConnection sqlConnection_2 = new SqlConnection(sql_data);
            if (idx < 0)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
                string product_class = datanames_1[idx]; //取得對應index的商品系列
                string product_list = $"[{product_class}]";
                string sqlstr = $"select * from {product_list} where [ID]={id}";
                Session["Sqlstr_class"] = product_class;
                Session["id_choose"] = id;
                SqlCommand sqlCommand_2 = new SqlCommand(sqlstr, sqlConnection_2);
                sqlConnection_2.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand_2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["Gird_check"] = 1;

                //取得商品原本型號
                SqlDataReader sqlDataReader_2 = sqlCommand_2.ExecuteReader();            
                if (sqlDataReader_2.HasRows)
                {
                    if(sqlDataReader_2.Read())
                    {
                        Session["org_type"] = sqlDataReader_2["型號"].ToString();
                    }  
                }
            }
            sqlConnection_2.Close();
        }
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

            if (!IsPostBack) //防止重複刷新==>造成只能選取第一項
            {
                //商品系列填入下拉式選單
                this.DropDownList1.DataSource = datanames;
                this.DropDownList1.DataBind();
                this.DropDownList1.Style["display"] = "none"; //將舊樣式的隱藏起來

                //check是否查詢過用
                Session["Gird_check"] = 0;
            }

            //新增商品種類的Textbox和buttom
            TextBox1.Attributes.Add("style", "font-size:Large;color:#666666");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DropDownList1.SelectedIndex - 1; //取得對應的index
            Session["Idx"] = idx;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idx = (int)Session["Idx"];
            BindGrid(idx, int.Parse(TextBox1.Text));
        }
        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/product_pic/");
            if (this.FileUpload1.HasFile)
            {
                string fileException = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileException.Equals(".jpg") || fileException.Equals(".png") || fileException.Equals(".jpeg"))
                {
                    if (Session["org_type"] == null)
                    {
                        Response.Write("<script>alert('請先選擇要更改的商品');</script>");
                    }
                    else
                    {
                        string new_name = Session["org_type"].ToString();

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
                    if (Session["org_type"] == null)
                    {
                        Response.Write("<script>alert('請先選擇要更改的商品');</script>");
                    }
                    else
                    {
                        string new_name = Session["org_type"].ToString();

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
                        this.FileUpload2.SaveAs(virpath_2);
                        ShowImage_2.ImageUrl = $"~/product_pic/{pic_name_2}";
                        ShowImage_2.Height = 200;
                        ShowImage_2.Width = 150;
                        Response.Write("<script>alert('上傳成功!');</script>");
                    }  
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
            if ((int)Session["Gird_check"] == 0)
            {
                Response.Write("<script>alert('請先查詢需要修改的商品!');</script>");
            }
            else
            {
                string Sqlstr_class = Session["Sqlstr_class"].ToString();
                int id_choose = (int)Session["id_choose"];

                string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(sql_data);

                //資料行名稱+value
                string sql_update = "SET ";

                if (TextBox2.Text != "")
                {
                    sql_update += $"[型號]=N'{TextBox2.Text}'";
                }
                if (TextBox3.Text != "")
                {
                    sql_update += $",[名稱]=N'{TextBox3.Text}'";
                }
                if (TextBox4.Text != "")
                {
                    sql_update += $",[規格]=N'{TextBox4.Text}'";
                }
                if (TextBox5.Text != "")
                {
                    sql_update += $",[尺寸]=N'{TextBox5.Text}'";
                }
                if (TextBox6.Text != "")
                {
                    sql_update += $",[牌價]='{int.Parse(TextBox6.Text)}'";
                }
                if (TextBox7.Text != "")
                {
                    sql_update += $",[售價]='{int.Parse(TextBox7.Text)}'";
                }
                if (TextBox8.Text != "")
                {
                    sql_update += $",[數量]='{int.Parse(TextBox8.Text)}'";
                }
                if (Session["Img_1"] != null)
                {
                    Img_1 = Session["Img_1"].ToString();
                    sql_update += $",[image_1]='{Img_1}'";
                }
                if (Session["Img_2"] != null)
                {
                    Img_2 = Session["Img_2"].ToString();
                    sql_update += $",[image_2]='{Img_2}'";
                }

                string updatesql = $"update [{Sqlstr_class}]{sql_update} where ID = {id_choose}";

                SqlCommand Command = new SqlCommand(updatesql, sqlConnection);

                Command.Connection.Open();

                Command.ExecuteNonQuery();

                Command.Connection.Close();

                Response.Write("<script>alert('修改成功!');</script>");

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
                GridView1.DataSource = null;
                GridView1.DataBind();
                Session["Gird_check"] = 0;
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagerPage.aspx");
        }
    }
}