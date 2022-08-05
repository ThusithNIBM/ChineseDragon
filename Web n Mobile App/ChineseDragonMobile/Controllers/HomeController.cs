using ChineseDragonMobile.API;
using ChineseDragonMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseDragonMobile.Controllers
{
    public class HomeController : Controller
    {
        OrderAPI _OrderAPI = new OrderAPI();

        public ActionResult Index()
        {
            ViewBag.menuiems = _OrderAPI.GetMnuItems();
            return View();
        }

        public ActionResult CreateOrder(CreateOrderDOM createOrder)
        {
            try
            {
                _OrderAPI.CreateOrder(createOrder);

                return Json(new APIresultDOM<bool>() { IsSuccess = true, SvrMsgTitle = "Successful", SvrMsgBody = "Successful" });
            }
            catch (Exception ex)
            {
                return Json(new APIresultDOM<bool>() { IsSuccess = false, SvrMsgTitle = "Unsuccessful", SvrMsgBody = ex.Message });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}