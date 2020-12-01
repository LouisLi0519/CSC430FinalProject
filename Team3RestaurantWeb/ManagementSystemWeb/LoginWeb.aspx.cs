using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.LoginWeb
{
    public partial class LoginWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string p = TxtPassword.Text.Trim();
            string u = TxtUserName.Text.Trim();
            if(p == "" || u == "")
            {
                Response.Write("<script language='javascript'>window.alert('Please Enter Username or password！');</script>");
                TxtPassword.Text = "";
                TxtUserName.Text = "";
                return;
            }
            Team3Restaurant.ManagementSystem.Login.LoginMagement loginSystem = new Team3Restaurant.ManagementSystem.Login.LoginMagement(u, p);
            if (!loginSystem.UserVerification())
            {
                Response.Write("<script language='javascript'>window.alert('Invalid Username or password！');</script>");
                TxtPassword.Text = "";
                TxtUserName.Text = "";
                return;
            }

            string s_url;
            s_url = "MainScreenWeb.aspx?stuffID=" + loginSystem.StuffID;
            Response.Redirect(s_url);
        }
    }
}