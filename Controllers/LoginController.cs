using BEANlayer;
using DAOlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TradingTool.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]   // Se ejecuta el Post cuando se hace accion con el BOTON  OJO----
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginBEAN plogin)
        {
            LoginBEAN loginBean = new LoginBEAN();
            loginBean = new LoginDAO().BuscarLoginByUserId(plogin);
            //         if (login.userID == "admin"  && login.userPassword == "admin" )
            if (loginBean.userID != null) 
            {
//                FormsAuthentication.SetAuthCookie(User.userID, true);
                Session["Login"] = plogin.userID;
                Session["Password"] = plogin.userPassword;
                return RedirectToAction("Index", "Portfolio"); // Method in Portfolio Controller
            }
            else 
            {
                return RedirectToAction("Login", "Login", new { message = "Invalid Login Information" }); // Method in Login  Controller
            }
        }
        
        [Authorize]
        public ActionResult Logout() {
            return RedirectToAction("Login", "Login", new { message = "" }); // Method in Login  Controller
        }
    }
}