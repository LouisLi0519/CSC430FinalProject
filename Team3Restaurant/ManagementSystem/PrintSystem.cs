using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class PrintSystem
    {
        public List<OrderList> ShowAllOrders()
        {
            OrderList OL = new OrderList();
            return OL.GetAllOrders();
        }
    }
}
