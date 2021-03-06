﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.ManagementSystemWeb
{
    public partial class OrderManagementWeb : System.Web.UI.Page
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


        protected void View_Click(object sender, EventArgs e)
        {

        }

        protected void GVOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void BtnViewOrder_Click(object sender, EventArgs e)
        {
            Button view = sender as Button;
            string orderID = view.CommandArgument;
            Team3Restaurant.ManagementSystem.OrderManagement OM = new Team3Restaurant.ManagementSystem.OrderManagement();
            List<Team3Restaurant.ManagementSystem.OrderView> orderView = OM.GetOrderDetail(orderID);
            GVOrderDetail.DataSource = orderView;
            GVOrderDetail.DataBind();
        }

        protected void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            Button order = sender as Button;
            string orderID = order.CommandArgument;
            string status = DLOrderStatus.SelectedValue;
            if (orderID == null)
                return;
            if (status.Equals("none"))
            {
                Response.Write("<script language='javascript'>window.alert('Please Select the Right Status！');</script>");
                return;
            }
         

            Team3Restaurant.ManagementSystem.OrderManagement OM = new Team3Restaurant.ManagementSystem.OrderManagement();
            OM.ChangeStatus(orderID, status);
            DLOrderStatus.SelectedValue = "none";
            GVOrderList.DataBind();

        }

        protected void BtnBackToMain_Click(object sender, EventArgs e)
        {
            string s_url;
            s_url = "MainScreenWeb.aspx?stuffID=" + Team3Restaurant.ManagementSystem.Login.LoginMagement._stuffID;
            Response.Redirect(s_url);
        }

        protected void DLOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}