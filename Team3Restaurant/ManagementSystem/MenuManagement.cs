using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class MenuManagement
    {
        public int ChangePrice(string menuID, string itemID, float price)
        {
            if (null == itemID || menuID == null || price == 0)
                return -1;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                string date = DateTime.Now.ToString(); ;
                command.Connection = connection;
                string commandString = "update menu set sale_price = "+ price +", last_edited_date = '"+ date + "' where menu_id = '" + menuID + "' and item_id='" + itemID + "'";

                command.CommandText = commandString;

                return command.ExecuteNonQuery();
            }
        }
        public int DeleteItem(string menuID, string itemID)
        {
            if (null == itemID || menuID == null)
                return -1;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                string commandString = "delete from menu where menu_id = '"+ menuID + "' and item_id='"+ itemID + "'";

                command.CommandText = commandString;

                return command.ExecuteNonQuery();
            }
        }
        public List<Menu> GetMenuIDAndType()
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<Menu> menus = new List<Menu>();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;
                string commandString = "select distinct menu_id, type from menu";

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Menu menu = new Menu();
                        menu.MenuID = reader["menu_id"].ToString().Trim();
                        menu.MenuType = reader["type"].ToString().Trim();
                        menus.Add(menu);
                    }
                }

                reader.Close();
            }
            return menus;
        }
        public List<MenuDetail> GetMenuDetails(string menuID)
        {
            if (menuID == null)
                return null;

            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<MenuDetail> menus = new List<MenuDetail>();

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;
                string commandString = "select item_id, last_edited_date, description, sale_price from menu where menu_id = '" + menuID + "'";

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuDetail menuDetail = new MenuDetail();
                        menuDetail.ItemID = reader["item_id"].ToString().Trim();
                        menuDetail.EditDate = reader["last_edited_date"].ToString().Trim();
                        menuDetail.ItemDesc = reader["description"].ToString().Trim();
                        menuDetail.SalePrice = "$" + float.Parse(reader.GetValue(3).ToString());
                        menus.Add(menuDetail);
                    }
                }

                reader.Close();
            }
            return menus;


        }
    }
    
    public class Menu
    {
        private string _menuID;
        private string _menuType;

        public string MenuID
        {
            set { _menuID = value; }
            get { return _menuID; }
        }
        public string MenuType
        {
            set { _menuType = value; }
            get { return _menuType; }
        }

    }
    public class MenuDetail
    {
        private string _itemID;
        private string _itemDesc;
        private string _salePrice;
        private string _editDate;
        
        public string EditDate
        {
            set { _editDate = value; }
            get { return _editDate; }
        } 
        public string ItemDesc
        {
            set { _itemDesc = value; }
            get { return _itemDesc; }
        } 
        public string SalePrice
        {
            set { _salePrice = value; }
            get { return _salePrice; }
        }
        public string ItemID
        {
            set { _itemID = value; }
            get { return _itemID; }
        }
    }
}
