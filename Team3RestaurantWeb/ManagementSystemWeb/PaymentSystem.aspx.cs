﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.ManagementSystemWeb
{
    public partial class PaymentSystem : System.Web.UI.Page
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            string orderID = lb.CommandArgument;
            if (orderID == null)
            {
                return;
            }
            string s_url;
            s_url = "receipt.aspx?orderID=" + orderID;
            Response.Redirect(s_url);

        }

        protected void BtnBackToMain_Click(object sender, EventArgs e)
        {
            string s_url;
            s_url = "MainScreenWeb.aspx?stuffID=" + Team3Restaurant.ManagementSystem.Login.LoginMagement._stuffID;
            Response.Redirect(s_url);
        }
    }
}