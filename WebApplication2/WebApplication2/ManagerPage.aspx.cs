﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace WebApplication2
{
    public partial class ManagerPage : System.Web.UI.Page
    {
        public List<string> datanames = new List<string>() { "請選擇" };

        //dataname_list(內部用)
        public List<string> datanames_1 = new List<string>() { };
        public int Idx;
        public int Idx_2;

        //訂單總覽用
        public List<string> order_list = new List<string>() { "請選擇", "未處理", "已處理" };

        public void BindGrid(int idx)  //商品呈現於Grid表格中
        {
            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;
            SqlConnection sqlConnection_1 = new SqlConnection(sql_data);
            if (idx < 0)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
                string product_class = datanames_1[idx]; //取得對應index的商品系列
                string product_list = $"[{product_class}]";
                string sqlstr = $"select [ID],[型號],[名稱],[規格],[尺寸],[牌價],[售價],[數量] from {product_list}";
                SqlCommand sqlCommand_1 = new SqlCommand(sqlstr, sqlConnection_1);
                sqlConnection_1.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand_1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            sqlConnection_1.Close();
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
                    if (sqlDataReader["Table_name"].ToString() == "database_firewall_rules")
                    {
                        continue;
                    }
                    else
                    {
                        datanames.Add(sqlDataReader["Table_name"].ToString().Replace("$", "").Replace("'", "").Replace("#", "。"));
                        datanames_1.Add(sqlDataReader["Table_name"].ToString());
                    }
                }
            }
            sqlConnection.Close();

            if (!IsPostBack) //防止重複刷新==>造成只能選取第一項
            {
                //商品系列填入下拉式選單
                this.DropDownList1.DataSource = datanames;
                this.DropDownList1.DataBind();
                this.DropDownList1.Style["display"] = "none"; //將舊樣式的隱藏起來

                //訂單list填入下拉式選單
                this.DropDownList2.DataSource = order_list;
                this.DropDownList2.DataBind();
                this.DropDownList2.Style["display"] = "none"; //將舊樣式的隱藏起來
            }  
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DropDownList1.SelectedIndex - 1; //取得對應的index
            Idx = idx;
            if(idx == -1)
            {
                Response.Write("<script>alert('請選擇正確的選項')</script>");
            }
            else
            {
                BindGrid(idx);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //初始化庫存提示
            Label3.Text = "";

            DataRowView drv = (DataRowView)e.Row.DataItem;

            if ((e.Row.RowType == DataControlRowType.DataRow) || (e.Row.RowType == DataControlRowType.Footer))
            {
                if (drv != null)
                {
                    if ((int)drv["數量"] < 25)  //當商品數量低於25個
                    {
                        e.Row.ForeColor = System.Drawing.Color.Red; //符合 => 背景改紅色警示
                        Label3.Text = "(注意!!!有庫存過低的商品!!)";
                        Label3.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }  
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvw = (GridView)sender;
            TextBox TextBox_PageSize = (TextBox)gvw.BottomPagerRow.FindControl("TextBox_PageSize");
            

            if (e.NewPageIndex < 0)
            {
                TextBox pageNum = (TextBox)gvw.BottomPagerRow.FindControl("txtNewPageIndex");
                int Pa = int.Parse(pageNum.Text);
                if (Pa <= 0)
                {
                    gvw.PageIndex = 0;
                }
                else
                {
                    gvw.PageIndex = Pa - 1;
                }
            }
            else
            {
                gvw.PageIndex = e.NewPageIndex;
            }
            BindGrid(Idx);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddProduct.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModifyProduct.aspx");
        }

        //訂單總覽

        public void BindGrid_2(int idx)  //商品呈現於Grid表格中
        {
            string sql_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AcountConnectionString"].ConnectionString;
            SqlConnection sqlConnection_2 = new SqlConnection(sql_data);
            string sqlstr = $"select * from Orders where done = {idx}";
            SqlCommand sqlCommand_2 = new SqlCommand(sqlstr, sqlConnection_2);
            sqlConnection_2.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand_2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dt.Columns.Add("細項連結");
            GridView2.DataSource = dt;
            GridView2.DataBind();

            sqlConnection_2.Close();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DropDownList2.SelectedIndex - 1; //取得對應的index
            Idx_2 = idx;
            if (idx == -1)
            {
                Response.Write("<script>alert('請選擇正確的選項')</script>");
            }
            else
            {
                BindGrid_2(idx);
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                if(Idx_2 == 0)
                {
                    HyperLink hyperLink = new HyperLink();
                    hyperLink.Text = "去處理";
                    hyperLink.NavigateUrl = $"item_overview.aspx?orderid={e.Row.Cells[0].Text}";
                    e.Row.Cells[5].Controls.Add(hyperLink);
                }
                else
                {
                    return;
                }
                
            }
        }
    }
}