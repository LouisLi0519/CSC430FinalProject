using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class OrderManagement
    {
        public void ChangeStatus(string orderID, string status)
        {
            if (null == orderID || status == null )
                return;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                string commandString = "update order_list set status = '"+ status + "' where order_id = '" + orderID + "'";

                command.CommandText = commandString;

                command.ExecuteNonQuery();
            }
        }
        public List<OrderView> GetOrderDetail(string orderID)
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<OrderView> list = new List<OrderView>();
            using (connection)
            {
                connection.Open();
                command.Connection = connection;
                string commandString = "select order_id,status, order_time,ipad_id,description,quantity from order_list where order_id = '" + orderID + "'";

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        OrderView row = new OrderView();
                        row.OrderID = reader["order_id"].ToString().Trim();
                        row.Status = reader["status"].ToString().Trim();
                        row.OrderTime = reader["order_time"].ToString().Trim();
                        row.IpadID = reader["ipad_id"].ToString().Trim();
                        row.Description = reader["description"].ToString().Trim();
                        row.Quantity = reader["quantity"].ToString().Trim();

                        list.Add(row);
                    }
                }

                reader.Close();

            }


            return list;
        }
        public List<OrderView> GetOrderList()
        {

            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<OrderView> list = new List<OrderView>();
            using (connection)
            {
                connection.Open();
                command.Connection = connection;
                string commandString = "select distinct order_id,status,order_time,ipad_id from order_list order by order_time ASC";

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        OrderView row = new OrderView();
                        row.OrderID = reader["order_id"].ToString().Trim();
                        row.Status = reader["status"].ToString().Trim();
                        row.OrderTime = reader["order_time"].ToString().Trim();
                        row.IpadID = reader["ipad_id"].ToString().Trim();

                        list.Add(row);
                    }
                }

                reader.Close();
          
            }


            return list;
        }

    }
   
}

