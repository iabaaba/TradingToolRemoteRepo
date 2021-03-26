using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradingTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Happy Trading Tool.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Happy Trading Tool.";

            return View();
        }
    }
}