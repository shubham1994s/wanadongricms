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

namespace SwachhBharatAbhiyan.CMS.Areas.Street.Controllers
{
    public class StreetSweepingController : Controller
    {


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

        public ActionResult Index()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
                return Redirect("/Account/Login");
        }


        public ActionResult MenuIndex()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                TempData.Keep();
                return View();
            }
            else
                return Redirect("/Account/Login");
        }

        public ActionResult AddStreetSweeping(int teamId = -1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                StreetSweepVM dump = childRepository.GetStreetSweepId(teamId);
                return View(dump);
            }
            else
                return Redirect("/Account/Login");
        }


        [HttpPost]
        public ActionResult AddStreetSweeping(StreetSweepVM LiquidWaste, HttpPostedFileBase filesUpload)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                var AppDetails = mainRepository.GetApplicationDetails(SessionHandler.Current.AppId);
                var guid = Guid.NewGuid().ToString().Split('-');
                string image_Guid = DateTime.Now.ToString("MMddyyyymmss") + "_" + guid[1] + ".jpg";

                //Converting  Url to image 
                // var url = string.Format("http://api.qrserver.com/v1/create-qr-code/?data="+ point.ReferanceId);

                var url = string.Format("https://chart.googleapis.com/chart?cht=qr&chl=" + LiquidWaste.ReferanceId + "&chs=160x160&chld=L|0");

                WebResponse response = default(WebResponse);
                Stream remoteStream = default(Stream);
                StreamReader readStream = default(StreamReader);
                WebRequest request = WebRequest.Create(url);
                response = request.GetResponse();
                remoteStream = response.GetResponseStream();
                readStream = new StreamReader(remoteStream);
                //Creating Path to save image in folder
                System.Drawing.Image img = System.Drawing.Image.FromStream(remoteStream);
                string imgpath = Path.Combine(Server.MapPath(AppDetails.basePath + AppDetails.StreetQRCode), image_Guid);
                var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.basePath + AppDetails.StreetQRCode));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(AppDetails.basePath + AppDetails.StreetQRCode));
                }
                img.Save(imgpath);
                response.Close();
                remoteStream.Close();
                readStream.Close();
                LiquidWaste.SSQRCode = image_Guid;

                StreetSweepVM pointDetails = childRepository.SaveStreetSweep(LiquidWaste);


                return Redirect("Index");
            }
            else
                return Redirect("/Account/Login");
        }


    }
}