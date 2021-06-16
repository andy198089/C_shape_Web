using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int product_class = int.Parse(Request["productclass"]);
            string product_type = Request["producttype"];
            Label2.Text = product_class + " " + product_type;
        }
    }
}