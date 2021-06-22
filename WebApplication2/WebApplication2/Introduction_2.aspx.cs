using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Introduction_2 : System.Web.UI.Page
    {
        protected void SubmitBtn_Click(Object Sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            //DataTable dt = new DataTable();
            //cmd = new SqlCommand();
            //cmd.CommandText = string.Format(@"
            //    select A.TABLE_NAME
            //    from( 
            //        select ROW_NUMBER() OVER(ORDER BY TABLE_NAME asc) as id,TABLE_NAME from INFORMATION_SCHEMA.TABLES
            //    ) A
            //    where TABLE_NAME=N'Detail'
            //");
            //dt = GetSQLDataTable(cmd);
            //if (dt.Rows.Count==0) {
            //    cmd = new SqlCommand();
            //    cmd.CommandText = string.Format(@"
            //      CREATE TABLE [dbo].[Detail](
	           //     [ID] [int] IDENTITY(1,1) NOT NULL,
	           //     [型號] [nvarchar](255) NULL,
	           //     [名稱] [nvarchar](255) NULL,
	           //     [規格] [nvarchar](255) NULL,
	           //     [尺寸] [nvarchar](255) NULL,
	           //     [售價] [int] NULL,
	           //     [數量] [int] NULL,
            //    ) ON [PRIMARY]");
            //    dt = GetSQLDataTable(cmd);
            //}
            //cmd = new SqlCommand();
            //cmd.CommandText = string.Format(@"
            //    select A.TABLE_NAME
            //    from( 
            //        select ROW_NUMBER() OVER(ORDER BY TABLE_NAME asc) as id,TABLE_NAME from INFORMATION_SCHEMA.TABLES
            //    ) A
            //    where TABLE_NAME=N'Detail'
            //");
         //   string dt = GetSQLNonQuery(cmd);




            // string a = Request["format1"];
            //string b = format.Text;
            //string c = number.Text;
            //string d = Label1.Text;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

                SqlCommand cmd = new SqlCommand();
                string from = "";
                int i = 0;
                int j = 0;
                DataTable dt = new DataTable();
                if (Request.QueryString.Count == 0)
                {
                    if (productclass.Text == "" && producttype.Text == "")
                    {
                        Response.Write("<script> alert('已經過時資料');</script>");
                    }

                }
                else {
                    if (Request.QueryString["productclass"] == null && Request.QueryString["productclass"] == "") Response.Write("<script> alert('無產品類別');</script>");
                    if (Request.QueryString["producttype"] == null && Request.QueryString["producttype"] == "") Response.Write("<script> alert('無產品型號');</script>");
                    productclass.Text = Request.QueryString["productclass"].ToString();
                    producttype.Text = Request.QueryString["producttype"].ToString();
                }

                //判斷哪個資料表
                cmd = new SqlCommand();
                cmd.CommandText = string.Format(@"
                select A.TABLE_NAME
                from( 
                   select ROW_NUMBER() OVER(ORDER BY TABLE_NAME asc) as id,TABLE_NAME from INFORMATION_SCHEMA.TABLES
                ) A
                where id=@id ");
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(productclass.Text);
                string FromName = GetSQLScalar(cmd);
                if (FromName == "") Response.Write("<script> alert('無產品類別');</script>");
                //查詢產品名稱
                cmd = new SqlCommand();
                from = "Products.dbo.[" + FromName + "]";
                cmd.CommandText = string.Format(@"select 型號,名稱,image_1 from {0} where 型號=@producttype ", from);
                cmd.Parameters.Add("@producttype", SqlDbType.VarChar).Value = producttype.Text;
                dt = GetSQLDataTable(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    Name.Text = dr["名稱"].ToString().Trim();
                    producttype.Text = dr["型號"].ToString().Trim();
                    Image.ImageUrl = "product_pic/" + dr["image_1"].ToString().Trim();

                }
                cmd = new SqlCommand();
                cmd.CommandText = string.Format(@"select 規格,尺寸 from {0} where 型號=@producttype ", from);
                cmd.Parameters.Add("@producttype", SqlDbType.VarChar).Value = producttype.Text;
                dt = GetSQLDataTable(cmd);
                ListItemCollection listBoxData = new ListItemCollection();
                i = 0;
                size.Text = "尺寸:";
                format.Text = "規格";
                foreach (DataRow dr in dt.Rows)
                {
                    if (i < dt.Rows.Count)
                    {
                        if (dr["規格"] != null && dr["規格"].ToString().Trim() != "")
                        {
                            listBoxData.Add(dr["規格"].ToString().Trim());

                        }
                    }

                    FormatButtonList1.DataSource = listBoxData;
                    FormatButtonList1.Attributes.Add("Name", "format" + i);
                    FormatButtonList1.DataBind();
                    if (i < dt.Rows.Count)
                    {
                        if (dr["尺寸"] != null && dr["尺寸"].ToString().Trim() != "")
                        {
                            listBoxData.Add(dr["尺寸"].ToString().Trim());

                        }
                    }
                    SizeButtonList1.DataSource = listBoxData;
                    SizeButtonList1.Attributes.Add("Name", "format" + i);
                    SizeButtonList1.DataBind();
                    i++;
                }
            
            




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