using ChineseDragon.API;
using ChineseDragon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseDragon.Controllers
{
    public class HomeController : Controller
    {
        OrderAPI _OrderAPI = new OrderAPI();

        public ActionResult Index()
        {
            ViewBag.orders = _OrderAPI.GetOrders();
            ViewBag.OrderCounts = _OrderAPI.GetOrderCounts();
            return View();
        }

        public ActionResult CashierWorkflow()
        {
            ViewBag.orders = _OrderAPI.GetOrders();
            ViewBag.OrderCounts = _OrderAPI.GetOrderCounts();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateKitchenWFBtn(int? id, int? status)
        {
            try
            {
                _OrderAPI.UpdateOrder(id.Value, status.Value + 1);

                return Json(new APIresultDOM<bool>() { IsSuccess = true, SvrMsgTitle = "Successful", SvrMsgBody = "Successful" });
            }
            catch (Exception ex)
            {
                return Json(new APIresultDOM<bool>() { IsSuccess = false, SvrMsgTitle = "Unsuccessful", SvrMsgBody = ex.Message });
            }
        }

        //public ActionResult GetOrderCounts()
        //{
            



        //}

    }
}