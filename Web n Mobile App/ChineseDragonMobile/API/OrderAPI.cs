using ChineseDragonMobile.Common.Functions;
using ChineseDragonMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ChineseDragonMobile.API
{
    public class OrderAPI
    {
        public List<MenuItemDOM> GetMnuItems()
        {
            string JSonString = null;
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();

            JSonString = APIaccess.GetResult(Common.Properties.APIs.OrderAPI, true, ChineseDragonMobile.Properties.Settings.Default.OrderAPI + "/api/order/getmenuitems", null);
            return JSserializer.Deserialize<List<MenuItemDOM>>(JSonString);
        }

        public Orders_rec GetOrders()
        {
            string JSonString = null;
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();

            JSonString = APIaccess.GetResult(Common.Properties.APIs.OrderAPI, true, ChineseDragonMobile.Properties.Settings.Default.OrderAPI + "/api/order/getorders", null);
            return JSserializer.Deserialize<Orders_rec>(JSonString);
        }

        public string UpdateOrder(int OrderID, int Status)
        {
            string JSonString = null;
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();

            JSonString = APIaccess.GetResult(Common.Properties.APIs.OrderAPI, false, ChineseDragonMobile.Properties.Settings.Default.OrderAPI + "/api/order/UpdateOrder", JSserializer.Serialize(new { OrderID = OrderID, OrderStatus = Status }));
            return JSserializer.Deserialize<string>(JSonString);
        }

        public string CreateOrder(CreateOrderDOM OrderRequest)
        {
            string JSonString = null;
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();

            JSonString = APIaccess.GetResult(Common.Properties.APIs.OrderAPI, false, ChineseDragonMobile.Properties.Settings.Default.OrderAPI + "/api/order/createorder", JSserializer.Serialize(OrderRequest));
            return JSserializer.Deserialize<string>(JSonString);
        }
    }
}