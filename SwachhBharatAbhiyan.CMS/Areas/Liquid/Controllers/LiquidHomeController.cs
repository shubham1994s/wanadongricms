using SwachBharat.CMS.Bll.Repository.ChildRepository;
using SwachBharat.CMS.Bll.Repository.MainRepository;
using SwachBharat.CMS.Bll.ViewModels.ChildModel.Model;
using SwachhBharatAbhiyan.CMS.Models.SessionHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SwachhBharatAbhiyan.CMS.Areas.Liquid.Controllers
{
    public class LiquidHomeController : Controller
    {


        IChildRepository childRepository;
        IMainRepository mainRepository;
        // GET: Liquid/LiquidHome
        public LiquidHomeController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                mainRepository = new MainRepository();
                childRepository = new ChildRepository(SessionHandler.Current.AppId);
            }
            else
                Redirect("/Account/Login");
        }
        public ActionResult Index()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                ViewBag.lat = SessionHandler.Current.Latitude;
                ViewBag.lang = SessionHandler.Current.Logitude;
                ViewBag.YoccFeddbackLink = SessionHandler.Current.YoccFeddbackLink;
                TempData.Keep();
                var details = childRepository.GetLiquidDashBoardDetails();
                return View(details);
            }
            else
                return Redirect("/Account/Login");
        }


     

    }
}