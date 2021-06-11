using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(Session["Logined"] == "login")
            {
                Session.RemoveAll();
                Response.Write("<script>alert('登出完成');location.href='Login.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('尚未登入');</script>");
            }
        }
    }
}