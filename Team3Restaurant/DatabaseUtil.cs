using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant
{
    internal class DatabaseUtil
    {
     //   private static SqlConnection sqlConnection = null;
        public static DbConnection GetConnection()
        {
 

            return new SqlConnection("Data Source=localhost;Initial Catalog=CSC430;Integrated Security=True"); 
        }
        public static DbCommand GetCommand()
        {
            return new SqlCommand();
        }
        public static DbParameter GetDbParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }
        public static string GetMenuItemQuery(string menuID)
        {
            return "select item.name, menu.type,menu.sale_price, menu.description from menu, item where menu_id = '"+ menuID + "' and item.item_id = menu.item_id" ;
        }
        public static string GetUnpaidOrderQuery()
        {
            return "select distinct order_id,ipad_id from order_list where status <> 'paid'";
        }
        public static string GetRecieptQuery(string orderID)
        {
            return @"select item.name,menu.sale_price,
                            a.quantity from menu,item,(select order_list.quantity, order_list.item_id, ipad.menu_id from order_list, 
                            ipad where order_id = '" + orderID + "' and order_list.ipad_id = ipad.ipad_id)" +
                            " as a where menu.menu_id = a.menu_id and menu.item_id = a.item_id and item.item_id = menu.item_id";
        }
        public static string GetItemIDQuery(string itemName)
        {
            return "select item_id from item where item.name ='" + itemName + "'";
        }
        public static string GetOrderListQuery(string iPadID)
        {
            return "select distinct order_id, status, order_time from order_list where ipad_id ='" + iPadID + "'";
        }
        public static string GetMenuIDQuery(string IPadID)
        {
            return "select menu_id from ipad where ipad_id = '" + IPadID + "'";
        }
        public static string GetCancelOrderQuery(string iPadID)
        {
            return "select distinct order_id from order_list where ipad_id = '" + iPadID + "' and status = 'confirmed'";
        }
        public static string GetUserVerificationQuery(string user, string password)
        {
            return "select stuff_id from stuff where user_name = '" + user + "' and password = '" + password + "'";
        }
    }
}
