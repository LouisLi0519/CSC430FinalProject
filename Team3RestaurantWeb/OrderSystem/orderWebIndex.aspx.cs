using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.OrderSystem
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            string iPadID = "I001";
            string menuID = OS.GetMenu(iPadID);
            string s_url;

            s_url = "OrderMenuWeb.aspx?menuID="+ menuID+"&iPadID=" + iPadID;
            Response.Redirect(s_url);
        }
    }
}