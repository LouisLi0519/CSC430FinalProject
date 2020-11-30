using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class PaymentManagemet
    {
        public int MakePayment(string orderID)
        {
            if (null == orderID )
                return -1;
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                string commandString = "update order_list set status = 'paid' where order_id = '" + orderID + "'";

                command.CommandText = commandString;

               return command.ExecuteNonQuery();
            }

        }
    }
}
