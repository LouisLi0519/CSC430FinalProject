﻿using System;
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
        protected void DLMenuID_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button delete = sender as Button;
            string itemID = delete.CommandArgument;
            string menuID = DLMenuID.SelectedValue;
            if (itemID == null)
                return;
            Team3Restaurant.ManagementSystem.MenuManagement MM = new Team3Restaurant.ManagementSystem.MenuManagement();

            if (MM.DeleteItem(menuID, itemID)>0)
            {
                Response.Write("<script language='javascript'>window.alert('Deleted');</script>");
                GVMenuDetail.DataBind();
            }
        }

        protected void GVMenuDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button changePrice = sender as Button;
            string itemID = changePrice.CommandArgument;
            string menuID = DLMenuID.SelectedValue;
            string price = TxtPrice.Text;
            if (price == "none")
                return;
            Team3Restaurant.ManagementSystem.MenuManagement MM = new Team3Restaurant.ManagementSystem.MenuManagement();
            float p = float.Parse(price);
            if (MM.ChangePrice(menuID, itemID, p) > 0)
            {
                Response.Write("<script language='javascript'>window.alert('Changed');</script>");
                GVMenuDetail.DataBind();
                TxtPrice.Text = "none";
            }
        }
    }
}