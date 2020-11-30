using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class OrderList
    {
        private string _orderid;
        private string _ipadid;

        public string IpadID
        {
            get { return _ipadid; }
            set { _ipadid = value; }
        }
        public string OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public List<OrderList> ShowUnpaidOrders()
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<OrderList> list = new List<OrderList>();
            try
            {
                connection.Open();
                command.Connection = connection;
                string commandString = DatabaseUtil.GetUnpaidOrderQuery();

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderList row = new OrderList();
                        row.OrderID = reader["order_id"].ToString().Trim();
                        row.IpadID = reader["ipad_id"].ToString().Trim();
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
}
