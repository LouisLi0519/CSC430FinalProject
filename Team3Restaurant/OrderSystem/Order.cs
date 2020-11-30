using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant
{
    public enum OrderStatus
    {
        confirmed,
        received,
        finished,
        paid,
        cancelled
    }
    public class Order
    {
        public static int _orderID = 0;
        private string _ipadID;
        private OrderStatus _status;
        private string _orderTime;

        //itemName-->Description-->quantity
        private Dictionary<string, Dictionary<string, int>> _itemDetail = new Dictionary<string, Dictionary<string, int>>();

        public Order()
        {
            _orderID++;
        }
        public string IPadID
        {
            set { _ipadID = value; }
            get { return _ipadID; }
        }
        public  OrderStatus Status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string OrderTime
        {
            set { _orderTime = value; }
            get { return _orderTime; }
        }
        public Dictionary<string,Dictionary<string,int>> ItemDetail
        {
            set { _itemDetail = value; }
            get { return _itemDetail; }
        }
        public int OrderID
        {
            get { return _orderID; }
        }
        public string GetItemID(string itemName)
        {
            if(null == itemName)
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
                string commandString = DatabaseUtil.GetItemIDQuery(itemName);

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        result = reader["item_id"].ToString();
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

    }
}
