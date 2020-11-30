using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class Receipt
    {
        private string _itemName;
        private float _price;
        private int _quantity;
        private float _subtotal;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public float Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        public List<Receipt> GetReceipt(string orderID)
        {
            if (null == orderID)
            {
                return null;
            }
            List<Receipt> result = new List<Receipt>();
            DbConnection connection = DatabaseUtil.GetConnection();

            DbCommand command = DatabaseUtil.GetCommand();

            try
            {
                connection.Open();
                command.Connection = connection;

                string query = DatabaseUtil.GetRecieptQuery(orderID);
                command.CommandText = query;
                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Receipt row = new Receipt();
                        row.ItemName = reader["name"].ToString();
                        row.Quantity = reader.GetInt32(2);
                        row.Price = float.Parse(reader.GetValue(1).ToString());
                        row.Subtotal = row.Price * row.Quantity;
                        result.Add(row);
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
