using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SwachhBharatAbhiyan.CMS.Models.SessionHelper;
using SwachBharat.CMS.Bll.Repository.MainRepository;
using SwachBharat.CMS.Bll.Repository.ChildRepository;
using SwachBharat.CMS.Bll.ViewModels.ChildModel.Model;

namespace SwachhBharatAbhiyan.CMS.Areas.Street.Controllers
{
    public class StreetLocationController : Controller
    {
        IMainRepository mainRepository;
        IChildRepository childRepository;
        public StreetLocationController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                mainRepository = new MainRepository();
                childRepository = new ChildRepository(SessionHandler.Current.AppId);
            }
            else
                Redirect("/Account/Login");
        }


        // GET: Street/StreetLocation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllHouseLocation()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                ViewBag.lat = SessionHandler.Current.Latitude;
                ViewBag.lang = SessionHandler.Current.Logitude;
                ViewBag.AppName = SessionHandler.Current.AppName;

                var details = childRepository.GetLiquidWasteDetails();
                return View(details);
            }
            else
                return Redirect("/Account/Login");
        }
    }
}