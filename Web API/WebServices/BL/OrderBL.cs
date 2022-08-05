using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServices.Models;
using WebServices.DL;

namespace WebServices.BL
{
    public class OrderBL
    {
        OrderDA OrdersDL = new OrderDA();
        internal List<MenuItemDOM> GetMenuItems()
        {
            return OrdersDL.GetMenuItems();
        }

        internal string CreateOrder(CreateOrderDOM orderRequest)
        {
            return OrdersDL.CreateOrder(orderRequest);
        }

        internal Orders_rec GetOrders()
        {
            return OrdersDL.GetOrders();
        }

        internal string UpdateOrder(int orderID, string Status)
        {
            return OrdersDL.UpdateOrder(orderID, Status);
        }

        internal OrderCountsDOM GetOrdersCounts()
        {
            return OrdersDL.GetOrderCounts();
        }
    }
}