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
        protected void DLMenuID_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        protected void GVMenuDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string s_url;
            s_url = "MainScreenWeb.aspx?stuffID=" + Team3Restaurant.ManagementSystem.Login.LoginMagement._stuffID;
            Response.Redirect(s_url);
        }

        protected void BtnChangePrice_Click(object sender, EventArgs e)
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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button delete = sender as Button;
            string itemID = delete.CommandArgument;
            string menuID = DLMenuID.SelectedValue;
            if (itemID == null)
                return;
            Team3Restaurant.ManagementSystem.MenuManagement MM = new Team3Restaurant.ManagementSystem.MenuManagement();

            if (MM.DeleteItem(menuID, itemID) > 0)
            {
                Response.Write("<script language='javascript'>window.alert('Deleted');</script>");
                GVMenuDetail.DataBind();
            }
        }

        protected void GVItemDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAddItem_Click(object sender, EventArgs e)
        {
            string menuID = DLMenuID.SelectedValue;
            Button button = sender as Button;
            string itemID = button.CommandArgument;
            string type = DLMenuType.SelectedValue;
            string desc = TxtDesc.Text;

            Team3Restaurant.ManagementSystem.MenuManagement MM = new Team3Restaurant.ManagementSystem.MenuManagement();
            if(MM.IsItemExist(menuID,itemID))
                Response.Write("<script language='javascript'>window.alert('Item Already Exist!!');</script>");
            else if (MM.AddItemToMenu(menuID, itemID, type, desc) > 0)
            {
                Response.Write("<script language='javascript'>window.alert('Added');</script>");
                GVMenuDetail.DataBind();
            }
        }
    }
}