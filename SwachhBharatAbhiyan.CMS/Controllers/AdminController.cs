using SwachBharat.CMS.Bll.Repository.MainRepository;
using SwachBharat.CMS.Bll.ViewModels.MainModel;
using SwachhBharatAbhiyan.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwachhBharatAbhiyan.CMS.Controllers
{
    public class AdminController : Controller
    {
        private IMainRepository mainrepository;
        public AdminController()
        {
            // AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            mainrepository = new MainRepository();
        }
        // GET: Admin
        public ActionResult MenuIndex()
        {
            List<MenuItem> menuList = GetMenus();
            return View(menuList);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menus()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(LoginViewModel model, string returnUrl)
        {
            if (model.Password == "Admin#123" & model.Email == "Admin")
            {

                return RedirectToAction("MenuIndex");
            }
            else {
                return View();

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult login1(LoginViewModel model, string returnUrl)
        {
            if (model.Password == "Admin#123" & model.Email == "Admin")
            {

                return RedirectToAction("MenuIndex");
            }
            else
            {
                return View();

            }
        }

        public List<MenuItem> GetMenus()
        {
            List<MenuItem> menuList = new List<MenuItem>();
            menuList = mainrepository.GetMenus();
            return menuList;
        }
        
    }
}