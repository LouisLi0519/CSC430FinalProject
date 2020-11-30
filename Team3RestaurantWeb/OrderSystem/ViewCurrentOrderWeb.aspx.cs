using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.OrderSystem
{
    public partial class ViewCurrentOrderWeb : System.Web.UI.Page
    {
        TextBox iPadID = new TextBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            iPadID.Text = Request.QueryString["iPadID"];
            DLDataBinding();
            
        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            string menuID = OS.GetMenu(iPadID.Text);
            string s_url;

            s_url = "OrderMenuWeb.aspx?menuID=" + menuID;
            Response.Redirect(s_url);
        }

        protected void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            string orderID = DLCancelOrder.SelectedValue;
            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            if(orderID == null)
            {
                return;
            }
            OS.CancelOrder(orderID);
            DLDataBinding();
            Response.Write("<script language='javascript'>window.alert('Succeeded！');</script>");
            string s_url;
            s_url = "ViewCurrentOrderWeb.aspx?iPadID=" + iPadID.Text;
            Response.Redirect(s_url);
        }

        protected void DLCancelOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DLDataBinding()
        {
            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            List<string> cancelOrderDataSource = OS.GetCancelOrderID(iPadID.Text);
            DLCancelOrder.DataSource = cancelOrderDataSource;
            DLCancelOrder.DataBind();
        }
        protected void CurrentOrderDataBinding()
        {
            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            List<Team3Restaurant.OrderList> currenOrderDataSource = OS.GetOrderList(iPadID.Text);
            GVOrderList.DataSource = currenOrderDataSource;
            GVOrderList.DataBind();
        }

        protected void GVOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}