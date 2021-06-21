using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace WebApplication2
{
    public partial class Vendor : System.Web.UI.Page
    {
        public virtual string ImageUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Image> Imges = new List<Image>() { Image1, Image2, Image3, Image4, Image5, Image6, Image7, Image8, Image9 };

            List<Label> Names = new List<Label>() { Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9 };

            List<Label> Phones = new List<Label>() { Phone1, Phone2, Phone3, Phone4, Phone5, Phone6, Phone7, Phone8, Phone9 };

            List<Label> Addresses = new List<Label>() { Address1, Address2, Address3, Address4, Address5, Address6, Address7, Address8, Address9 };

            List<HtmlGenericControl> Frames = new List<HtmlGenericControl>() { Frame1, Frame2, Frame3, Frame4, Frame5, Frame6, Frame7, Frame8, Frame9 };

            string v_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["VendorConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(v_data);

            string sqlVendor = "select jpg,name,phone,address,no from vendor";

            SqlCommand Command = new SqlCommand(sqlVendor, connection);

            connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();


            if (Reader.HasRows)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (Reader.Read())
                    {
                        Imges[i].ImageUrl = "png/" + (Reader[0]);
                        Names[i].Text = Reader[1].ToString();
                        Phones[i].Text = Reader[2].ToString();
                        Addresses[i].Text = Reader[3].ToString();
                    }
                    else
                    {
                        Frames[i].Style["display"] = "none";
                    }
                }
                connection.Close();
            }
        }
    }
}
