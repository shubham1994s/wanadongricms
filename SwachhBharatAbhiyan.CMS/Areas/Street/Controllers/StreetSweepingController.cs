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
using SwachBharat.CMS.Bll.Repository.ChildRepository;
using SwachBharat.CMS.Bll.Repository.MainRepository;
using SwachhBharatAbhiyan.CMS.Models.SessionHelper;

namespace SwachhBharatAbhiyan.CMS.Areas.Street.Controllers
{
    public class StreetSweepingController : Controller
    {

        IMainRepository mainRepository;
        IChildRepository childRepository;

        IChildRepository childRepository;
        IMainRepository mainRepository;
        // GET: Liquid/LiquidHome
        public StreetSweepingController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                mainRepository = new MainRepository();
                childRepository = new ChildRepository(SessionHandler.Current.AppId);
            }
            else
                Redirect("/Account/Login");
        }
        // GET: Liquid/LiquidWaste

        // GET: Street/StreetSweeping
        public ActionResult StreetSweepingIndex()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
                return Redirect("/Account/Login");
        }
        public ActionResult MenuStreetSweepingIndex()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                TempData.Keep();
                return View();
            }
            else
                return Redirect("/Account/Login");
        }

        public ActionResult MenuEntryDetails()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
                return Redirect("/Account/Login");
        }
        public ActionResult EntryDetails()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
                return Redirect("/Account/Login");
        }
        public ActionResult MenuIdealtime()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
                return Redirect("/Account/Login");
        }
        public ActionResult Idealtime()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
                return Redirect("/Account/Login");
        }
                img.Save(imgpath);
                response.Close();
                remoteStream.Close();
                readStream.Close();
                LiquidWaste.SSQRCode = image_Guid;

                StreetSweepVM pointDetails = childRepository.SaveStreetSweep(LiquidWaste);


        //Add by neha 12 june 2019
        public ActionResult IdleTime_Route()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                //ViewBag.userId = userId;
                //ViewBag.Date = Date;
                //return Json(userId, JsonRequestBehavior.AllowGet);
                return View();
            }
            else
                return Redirect("/Account/Login");
        }


    }
}