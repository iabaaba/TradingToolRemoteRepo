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
            string sessionValue = Session["Login"].ToString();
            
            listPorf = portfDAO.portfolioComposicion(sessionValue);
            return View(listPorf);
        }
        [HttpGet]
        public ActionResult PortfolioRegister()
        {
            ExchangeDAO exchangeDspDAO= new ExchangeDAO();
            ViewData["DisplayExchange"] = exchangeDspDAO.exchangeDisplayTbl();

            ShareStatusDAO shareStatusDspDAO = new ShareStatusDAO();
            ViewData["DisplayShareStatus"] = shareStatusDspDAO.shareStatusDisplayTbl();

            FinantialMarketDAO finantialMarketDspDAO = new FinantialMarketDAO();
            ViewData["DisplayFinantialMarket"] = finantialMarketDspDAO.finantialMarketDisplayTbl();

            SourceDAO sourceDspDAO = new SourceDAO();
            ViewData["DisplaySource"] = sourceDspDAO.sourceDisplayTbl();

            SectorDAO sectorDspDAO = new SectorDAO();
            ViewData["DisplaySector"] = sectorDspDAO.sectorDisplayTbl();

            IndustryDAO industryDspDAO = new IndustryDAO();
            ViewData["DisplayIndustry"] =  industryDspDAO.industryDisplayTbl();

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePortfolio(PortfolioBEAN portfo) 
        {
            portfo.userID = Session["Login"].ToString();
            portfo.timeUpdated = DateTime.Now;
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