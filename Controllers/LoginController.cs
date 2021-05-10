﻿using BEANlayer;
using DAOlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradingTool.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]   // Se ejecuta el Post cuando se hace accion con el BOTON  OJO----
        public ActionResult Login(LoginBEAN plogin)
        {
            
            LoginBEAN loginBean = new LoginBEAN();
            loginBean = new LoginDAO().BuscarLoginByUserId(plogin);
 //         if (login.userID == "admin"  && login.userPassword == "admin" )
            if (loginBean.userID !=null)
            {
                Session["Login"] = plogin.userID;
                Session["Password"] = plogin.userPassword;
                return RedirectToAction("Index", "Portfolio"); // Method in Portfolio Controller
            }
            return View();
        }
    }
}