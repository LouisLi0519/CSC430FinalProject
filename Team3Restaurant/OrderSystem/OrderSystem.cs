using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;


namespace Team3Restaurant
{
    public class OrderSystem
    {

        public void CancelOrder(string orderID)
        {
            if (null == orderID)
                return;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                    string commandString = "update order_list set status = 'cancelled' where order_id = '" + orderID + "'";

                    command.CommandText = commandString;
                    
                    command.ExecuteNonQuery();
                }
        }
        
        public List<string> GetCancelOrderID(string iPadID)
        {
            if (null == iPadID)
                return null;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<string> orders = new List<string>();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;
                string commandString = DatabaseUtil.GetCancelOrderQuery(iPadID);

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string row = reader["order_id"].ToString().Trim();

                        orders.Add(row);
                    }
                }

                reader.Close();
            }
            return orders;
        }

        public void MakeOrder(Order order)
        {
            if(null == order)
            {
                return;
            }
            string order_id = "O" + order.OrderID;
            string ipad_id = order.IPadID;
            string status = order.Status.ToString();
            string time = order.OrderTime;
            string itemID = null;
            string desc = null;
            int quantity = 0;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = null;


           using (connection) {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                foreach (KeyValuePair<string, Dictionary<string, int>> kvp in order.ItemDetail)
                {
                    command = DatabaseUtil.GetCommand();
                    command.Connection = connection;
                    string key = kvp.Key;
                    itemID = order.GetItemID(key);

                    Dictionary<string, int> valuePairs = kvp.Value;
                    foreach(KeyValuePair<string, int> kv in valuePairs)
                    {
                        desc = kv.Key;
                        quantity = kv.Value;
                    }
                   
                    string commandString = "Insert Into order_list(order_id, item_id,ipad_id, status, description, order_time, quantity)values(@orderID,@itemID,@IPadID,@status,@desc,@time,@quantity)";


                    command.CommandText = commandString;
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@orderID", order_id));
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@itemID", itemID));
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@IPadID", ipad_id));
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@status", status));
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@desc", desc));
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@time", time));
                    command.Parameters.Add(DatabaseUtil.GetDbParameter("@quantity", quantity));

                   
                    command.ExecuteNonQuery();
                }


               
            }
      
        }
        public string GetMenu(string IPadID)
        {
            if (null == IPadID)
            {
                return null;
            }
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            string result = null;
            try
            {
                connection.Open();
                command.Connection = connection;
                string commandString = DatabaseUtil.GetMenuIDQuery(IPadID);

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        result = reader["menu_id"].ToString();
                    }
                }

                reader.Close();
            }
            catch (DbException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }


            return result;
        
    }
        public List<MenuItem> ShowMenuItems(string menuID)
        {
            if (null == menuID)
                return null;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<MenuItem> list = new List<MenuItem>();
            try
            {
                connection.Open();
                command.Connection = connection;
                string commandString = DatabaseUtil.GetMenuItemQuery(menuID);

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                        MenuItem row = new MenuItem();
                        row.ItemName = reader["name"].ToString().Trim();
                        row.ItemType = reader["type"].ToString().Trim();
                        row.Price = float.Parse(reader.GetValue(2).ToString());
                        row.Description = reader["description"].ToString();
                        list.Add(row);
                    }
                }

                reader.Close();
            }
            catch (DbException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }


            return list;
        }
        public List<OrderList> GetOrderList(string iPadID)
        {
            if (iPadID == null)
                return null;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<OrderList> list = new List<OrderList>();
            try
            {
                connection.Open();
                command.Connection = connection;
                string commandString = DatabaseUtil.GetOrderListQuery(iPadID);

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        OrderList row = new OrderList();
                        row.OrderNum = reader["order_id"].ToString().Trim();
                        row.Status = reader["status"].ToString().Trim();
                        row.OrderTime = reader["order_time"].ToString().Trim();

                        list.Add(row);
                    }
                }

                reader.Close();
            }
            catch (DbException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }


            return list;
        }
      
    }
    public class OrderList
    {
        private string _orderNum;
        private string _status;
        private string _orderTime;
        public string OrderNum
        {
            set { _orderNum = value; }
            get { return _orderNum; }
        }
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string OrderTime
        {
            set { _orderTime = value; }
            get { return _orderTime; }
        }

    }

    public class MenuItem
    {
        private string _itemName;
        private string _itemType;
        private float _price;
        private string _description;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public string ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }

}
