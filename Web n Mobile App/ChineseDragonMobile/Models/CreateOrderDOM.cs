using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseDragonMobile.Models
{
    public class CreateOrderDOM
    {
        public string OrderType { get; set; }
        public string OrderThrough { get; set; }
        public string OrderUser { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItemsDOM> OrderItems { get; set; }
    }
}