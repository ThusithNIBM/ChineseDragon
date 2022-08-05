using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class OrderItemsDOM
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int MenuItemID { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
    }
}