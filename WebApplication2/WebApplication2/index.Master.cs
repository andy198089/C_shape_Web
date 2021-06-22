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
            if (Session["Logined"] == "login")
            {
                Button2.Text = "LOGOUT";
                Button1.Visible = false;
                Label1.Visible = true;
                Label1.Text = "HI!" + Session["userName"];
            }
            else
            {
                Button2.Text = "LOGIN";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["Logined"] != "login")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.RemoveAll();
                Response.Write("<script>alert('登出成功');location.href='Login.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Logined"] != "login")
            {
                Response.Redirect("Signup.aspx");
            }
        }
    }
}