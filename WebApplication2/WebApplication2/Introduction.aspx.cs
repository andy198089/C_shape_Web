using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Introduction : System.Web.UI.Page
    {


        protected void SubmitBtn_Click(Object Sender, EventArgs e)
        {
            string a= Request["format1"];
            //string b = format.Text;
            //string c = number.Text;
            //string d = Label1.Text;
        }
        [WebMethod]
        public static string GetData(string aa) 
        {


            return "test";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            string from = "";
            int i = 0;
            int j = 0;
            DataTable dt = new DataTable();
            if (Request.QueryString["productclass"] == null && Request.QueryString["productclass"] == "") Response.Write("<script> alert('無產品類別');</script>");
            if (Request.QueryString["producttype"] == null && Request.QueryString["producttype"] == "") Response.Write("<script> alert('無產品型號');</script>");
            ListItemCollection sizeBoxData = new ListItemCollection();
            ListItemCollection formatBoxData = new ListItemCollection();
            string id = Request.QueryString["productclass"];
            //判斷哪個資料表
            cmd = new SqlCommand();
            cmd.CommandText = string.Format(@"
                select A.TABLE_NAME
                from( 
                   select ROW_NUMBER() OVER(ORDER BY TABLE_NAME asc) as id,TABLE_NAME from INFORMATION_SCHEMA.TABLES
                ) A
                where id=@id ");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(id);
            string FromName = GetSQLScalar(cmd);
            if (FromName == "") Response.Write("<script> alert('無產品類別');</script>");


            id = Request.QueryString["producttype"];
            //查詢產品名稱
            cmd = new SqlCommand();
            from = "Products.dbo.[" + FromName + "]";
            cmd.CommandText = string.Format(@"select 名稱 from {0} where 型號=@producttype ", from);
            cmd.Parameters.Add("@producttype", SqlDbType.VarChar).Value = id;
            string ProductName = GetSQLScalar(cmd);
            if (ProductName == "") Response.Write("<script> alert('無產品名稱');</script>");
            //textLabels.Add(new TextLabel() { Name = ProductName });

            Panel title = new Panel();
            title.ID = "title";
            title.CssClass = "";
            this.DivAll.Controls.Add(title);
            Literal literal = new Literal();
            literal.Text = ProductName;
            title.Controls.Add(literal);
            this.DivAll.Controls.Add(title);

            //查詢多個產品型號跟圖片
            cmd = new SqlCommand();
            cmd.CommandText = string.Format(@"select [型號],[名稱],COUNT(名稱) as 總數 ,image_1 from {0} where 名稱= {1} group by 型號,名稱,image_1", from, "N'" + ProductName + "'");
            dt = GetSQLDataTable(cmd);
            if (dt.Rows.Count == 0) Response.Write("<script> alert('無產品型號');</script>");
            i = 0;    
            foreach (DataRow dr in dt.Rows)
            {
                if (i < dt.Rows.Count)
                {
                    title = new Panel();
                    title.ID = "ProductNumber" + i;
                    title.CssClass = "PanelAll";
                  
                    this.DivAll.Controls.Add(title);
                    literal = new Literal();
                    literal.Text = dr["型號"].ToString().Trim() + "<br>";
                    title.Controls.Add(literal);
                    this.DivAll.Controls.Add(title);
                    cmd = new SqlCommand();
                    cmd.CommandText = string.Format(@"select 規格,尺寸 from {0} where 型號=@producttype ", from);
                    cmd.Parameters.Add("@producttype", SqlDbType.VarChar).Value = dr["型號"].ToString().Trim();
                    DataTable dt2 = GetSQLDataTable(cmd);
                    if (dt2.Rows.Count == 0) Response.Write("<script> alert('無產品型號');</script>");
                    Image image = new Image();
                    image.ImageUrl = "product_pic/" + dr["image_1"].ToString().Trim();
                    image.ID = "'" + i + "''";
                    image.CssClass = "imageBig";
                    title.Controls.Add(image);
                    
                    Literal FormatLiteral = new Literal();
                    FormatLiteral.Text = dr["型號"].ToString().Trim() + "規格:";
                    title.Controls.Add(FormatLiteral);
                    j = 0;
                    RadioButtonList Format = new RadioButtonList();
                    ListItemCollection listBoxData = new ListItemCollection();
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        if (j < dt2.Rows.Count)
                        {
                            if (dr2["規格"] != null && dr2["規格"].ToString().Trim() != "")
                            {
                                listBoxData.Add(dr2["規格"].ToString().Trim());
                                
                            }
                        }
                        j++;
                    }
                    Format.DataSource = listBoxData;
                    Format.Attributes.Add("Name", "format" + i);
                    Format.DataBind();
                    title.Controls.Add(Format);

                    Literal SizeLiteral = new Literal();
                    SizeLiteral.Text = dr["型號"].ToString().Trim() + "尺寸:";
                    title.Controls.Add(SizeLiteral);
                    j = 0;
                    RadioButtonList Size = new RadioButtonList();
                    listBoxData = new ListItemCollection();
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        if (j < dt2.Rows.Count)
                        {
                            if (dr2["尺寸"] != null && dr2["尺寸"].ToString().Trim() != "")
                            {
                                listBoxData.Add(dr2["尺寸"].ToString().Trim());

                            }
                        }
                        j++;
                    }
                    Size.DataSource = listBoxData;
                    Size.Attributes.Add("Name", "Size" + i);
                    Size.Attributes.Add("class", "Size" + i);
                    Size.DataBind();
                    title.Controls.Add(Size);
                    this.DivAll.Controls.Add(title);
                 //   this.DivAll.Controls.Add(SizeDiv);
                 //   this.DivAll.Controls.Add(FormatDiv);

                }
                i++;
            }
            //TextBox tb = new TextBox();
            //tb.Attributes.Add("Type", "number");
            //tb.Attributes.Add("onclick", "aaa");
           
            //this.DivAll.Controls.Add(tb);
            //literal = new Literal();
            //literal.Text = "總金額:";
            //this.DivAll.Controls.Add(literal);
            //literal = new Literal();
            //literal.Text = "##";
            //this.DivAll.Controls.Add(literal);
            //Button button1 = new Button();
            //button1.ID = "save";
            //button1.Text = "結帳";
            //button1.OnClientClick = "SubmitBtn_Click";
           
            //this.DivAll.Controls.Add(button1);

        }

        #region Other
        private static string ExString;
        private static readonly string Sqlconn = ConfigurationManager.AppSettings["SqlConnection"];
        private string GetSQLScalar(SqlCommand cmd)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(Sqlconn))
            {
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    object oo = cmd.ExecuteScalar();
                    if (oo != null)
                        Result = oo.ToString();
                    conn.Close();
                    cmd.Dispose();
                    ExString = "Sql OK ";
                }
                catch (Exception ex)
                {
                    ExString = ex.ToString();
                    Result = "";
                }
                return Result;
            }
        }
        private string GetSQLNonQuery(SqlCommand cmd)
        {
            string Result = "ok";
            try
            {
                using (SqlConnection conn = new SqlConnection(Sqlconn))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cmd.Dispose();
                    ExString = "Sql OK ";
                }
            }
            catch (Exception ex)
            {
                ExString = ex.ToString();
                Result = "";
            }
            return Result;
        }
        private DataTable GetSQLDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(Sqlconn))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    conn.Close();
                    cmd.Dispose();
                    ExString = "Sql OK ";
                }
            }
            catch (Exception ex)
            {
                ExString = ex.ToString();
                Response.Write("<script>alert('無法讀取資料');</script>");
            }
            return dt;
        }
        #endregion




    }


}