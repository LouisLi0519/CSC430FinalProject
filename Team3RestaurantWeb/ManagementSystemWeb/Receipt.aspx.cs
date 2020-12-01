using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb.ManagementSystemWeb
{
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Team3Restaurant.ManagementSystem.Login.LoginMagement.IsLogin())
            {
                string s_url;
                s_url = "LoginWeb.aspx";
                Response.Redirect(s_url);
            }
            TxtOrderID.Text = Request.QueryString["orderID"];
            TxtDateTime.Text = DateTime.Now.ToString();
            float total = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                string s = (DataList1.Items[i].FindControl("SubtotalLabel") as Label).Text;
                total += float.Parse(s);
            }
            TxtTotal.Text = total.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Team3Restaurant.ManagementSystem.PaymentManagemet PM = new Team3Restaurant.ManagementSystem.PaymentManagemet();
            if (PM.MakePayment(TxtOrderID.Text) > 0)
            {
                Response.Redirect("PaymentSystem.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Update not done！');</script>");
            }
            
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentSystem.aspx");
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrintSystemWeb.aspx");
        }
    }
}