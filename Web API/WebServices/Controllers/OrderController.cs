using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;
using WebServices.BL;

namespace WebServices.Controllers
{
    [Authorize]
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        OrderBL OrdersBL = new OrderBL();

        [Route("getmenuitems")]
        [HttpGet]
        public List<MenuItemDOM> GetMenuItems()
        {
            List<MenuItemDOM> MenuItems = OrdersBL.GetMenuItems();

            return MenuItems;
        }

        [Route("createorder")]
        [HttpPost]
        public string CreateOrder(CreateOrderDOM OrderRequest)
        {
            string Responce = OrdersBL.CreateOrder(OrderRequest);

            return Responce;

        }

        [Route("getorders")]
        [HttpGet]
        public Orders_rec GetOrders()
        {
            Orders_rec Responce = OrdersBL.GetOrders();

            return Responce;

        }

        [Route("UpdateOrder")]
        [HttpPost]
        public string UpdateOrder(OrderItemsResponceDOM orderdata)
        {
            string Responce = OrdersBL.UpdateOrder(orderdata.OrderID, orderdata.OrderStatus);

            return Responce;

        }

        [Route("GetOrderCounts")]
        [HttpGet]
        public OrderCountsDOM GetOrderCounts()
        {
            OrderCountsDOM Responce = OrdersBL.GetOrdersCounts();

            return Responce;

        }

      


    }
}
