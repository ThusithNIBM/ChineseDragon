using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class OrderItemsResponceDOM
    {
        public int OrderID { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderThrough { get; set; }
        public string OrderUser { get; set; }
        public string OrderStatus { get; set; }
        public IList<OrderItemsDOM> OrderItems { get; set; }
    }
}