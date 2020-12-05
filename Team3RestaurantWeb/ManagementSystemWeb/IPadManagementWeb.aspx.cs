using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.ManagementSystemWeb
{
    public partial class IPadManagementWeb : System.Web.UI.Page
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

        protected void DLMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnApply_Click(object sender, EventArgs e)
        {
            string ipadID = DLIPad.SelectedValue;
            string menuID = DLMenu.SelectedValue;
            Team3Restaurant.ManagementSystem.IPadManagement IM = new Team3Restaurant.ManagementSystem.IPadManagement();
            if(IM.UpdateMenuToIPad(ipadID, menuID) != 0)
            {
                Response.Write("<script language='javascript'>window.alert('Done!');</script>");
                GVIPad.DataBind();
   //             Response.Redirect("IPadManagementWeb.aspx");
            }
                

        }

        protected void BtnBackToMain_Click(object sender, EventArgs e)
        {
            string s_url;
            s_url = "MainScreenWeb.aspx?stuffID=" + Team3Restaurant.ManagementSystem.Login.LoginMagement._stuffID;
            Response.Redirect(s_url);
        }
    }
}