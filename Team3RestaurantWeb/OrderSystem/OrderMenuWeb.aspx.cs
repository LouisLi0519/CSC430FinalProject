using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team3RestaurantWeb
{
    public partial class OrderMenuWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtIPadID.Text = "I001";
            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            string menuID = OS.GetMenu(TxtIPadID.Text);

        }



        protected void BtnMakeOrder_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Team3Restaurant.Order order = new Team3Restaurant.Order();
            order.IPadID = TxtIPadID.Text;
            order.OrderTime = DateTime.Now.ToString();
            order.Status = Team3Restaurant.OrderStatus.confirmed;

            Team3Restaurant.OrderSystem OS = new Team3Restaurant.OrderSystem();
            int row = GVMenu.Rows.Count;
            int col = GVMenu.Columns.Count;
            for(int i=  0; i < row; i++)
            {
                DropDownList quantity = (DropDownList)GVMenu.Rows[i].FindControl("Quantity");
                if(quantity.SelectedIndex != 0)
                {
                    Dictionary<string, int> detail = new Dictionary<string,int>();
                    string[] str = new string[col];
                    for (int j = 0; j < col-1; j++)
                    {
                        str[j] = GVMenu.Rows[i].Cells[j].Text;
                    }
                    detail.Add(str[3], quantity.SelectedIndex);
                    order.ItemDetail.Add(str[0], detail); 
                    flag = true;
                }
               
                
            }
            if (!flag)
            {
                Response.Write("<script language='javascript'>window.alert('Please Select Item First！');</script>");
                return;
            }
            OS.MakeOrder(order);
            Response.Write("<script language='javascript'>window.alert('Succeeded！');</script>");
            ClearSelection();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnClearOrder_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }
        private void ClearSelection()
        {
            int row = GVMenu.Rows.Count;
            int col = GVMenu.Columns.Count;
            for (int i = 0; i < row; i++)
            {
                DropDownList quantity = (DropDownList)GVMenu.Rows[i].FindControl("Quantity");
                if (quantity.SelectedIndex != 0)
                {
                    quantity.SelectedIndex = 0;
                }


            }
        }

        protected void BtnViewOrder_Click(object sender, EventArgs e)
        {

            string s_url;
            s_url = "ViewCurrentOrderWeb.aspx?iPadID=" +TxtIPadID.Text;
            Response.Redirect(s_url);

        }
    }
}