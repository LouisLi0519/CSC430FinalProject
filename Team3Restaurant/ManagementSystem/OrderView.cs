using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class OrderView
    {
        private string _orderID;
        private string _ipadID;
        private string _status;
        private string _orderTime;
        private string _description;
        private string _quantity;

        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        public string Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        public string OrderID
        {
            set { _orderID = value; }
            get { return _orderID; }
        }
        public string IpadID
        {
            set { _ipadID = value; }
            get { return _ipadID; }
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
}
