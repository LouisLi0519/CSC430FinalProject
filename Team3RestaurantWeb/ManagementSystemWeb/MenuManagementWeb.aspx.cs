using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.ManagementSystemWeb
{
    public partial class MenuManagementWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Team3Restaurant.ManagementSystem.Login.LoginMagement.IsLogin())
            {
                string s_url;
                s_url = "LoginWeb.aspx";
                Response.Redirect(s_url);
            }
        }
    }
}