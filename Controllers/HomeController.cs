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
            ViewBag.Message = "Happy Portfolio Tool.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Happy Portfolio Tool.";

            return View();
        }

        public ActionResult Support()
        {
            ViewBag.Message = "Help Us keeping running this Trading Tool.";

            return View();
        }
    }
}