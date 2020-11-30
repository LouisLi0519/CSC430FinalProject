using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.ManagementSystemWeb.MainScreenWeb
{
    public partial class MainScreenWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {     
            if (!Team3Restaurant.ManagementSystem.Login.LoginMagement.IsLogin())
            {
                string s_url;
                s_url = "LoginWeb.aspx";
                Response.Redirect(s_url);
            }
            TxtStuffID.Text = Request.QueryString["stuffID"].Trim();

        }

        protected void StuffID_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void LBIPadManagment_Click(object sender, EventArgs e)
        {
            Response.Redirect("IPadManagementWeb.aspx");
        }

        protected void LBMenuMagament_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuManagementWeb.aspx");
        }

        protected void LBOrderManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderManagementWeb.aspx");
        }

        protected void LBPaymentSystem_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentSystem.aspx");
        }

        protected void LBPrintSystem_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrintSystemWeb.aspx");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Team3Restaurant.ManagementSystem.Login.LoginMagement.Logout();
            Response.Redirect("LoginWeb.aspx");

        }
    }
}