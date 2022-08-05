using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseDragon.Models
{
    public class MenuItemDOM
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string PortionSize { get; set; }
        public decimal ItemPrice { get; set; }
    }
}