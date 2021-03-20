using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEANlayer;
using DAOlayer;

namespace TradingTool.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioDAO portfDAO = new PortfolioDAO();
        // GET: Portfolio
        [HttpGet]
        public ActionResult Index()
        {
            PortfolioDAO portfDAO = new PortfolioDAO();
            List<PortfolioBEAN> listPorf = new List<PortfolioBEAN>();
            listPorf = portfDAO.portfolioComposicion();
            return View(listPorf);
        }
        [HttpGet]
        public ActionResult PortfolioRegister()
        {
            ExchangeDAO exchangeDspDAO= new ExchangeDAO();
            ViewData["DisplayExchange"] = exchangeDspDAO.exchangeDisplayTbl();

            ShareStatusDAO shareStatusDspDAO = new ShareStatusDAO();
            ViewData["DisplayStatus"] = shareStatusDspDAO.shareStatusDisplayTbl();

            return View();
        }
        
        [HttpPost]
        public ActionResult CreatePortfolio(PortfolioBEAN portfo) 
        {
            PortfolioDAO porfDAO = new PortfolioDAO();
            bool answer = porfDAO.PortfolioRegister(portfo);
            if (answer)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

    }
}