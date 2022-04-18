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
         IMainRepository mainrepository;
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

        //public ActionResult MenuIndex()
        //{
        //    List<MenuItemULB> menuList = GetULBMenus();
        //    return View("MenuIndex2", menuList);
        //}
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


        public List<MenuItemULB> GetULBMenus()
        {
            List<MenuItemULB> menuList = new List<MenuItemULB>();
            menuList = mainrepository.GetULBMenus();
            return menuList;
        }


   

        public ActionResult AddAUREmployeeDetails(int teamId = -1)
        
        {        
            AEmployeeDetailVM division = mainrepository.GetDivision();
           
            return View(division);
        }

        [HttpPost]
        public ActionResult LoadDistrictListList(int Id)

        {

            AEmployeeDetailVM division = mainrepository.GetDistrict(Id);

            return Json(division.DistrictList, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult LoadDistrictListList(int Id)

        //{

        //    AEmployeeDetailVM division = mainrepository.GetDistrict(Id);

        //    return View("AddAUREmployeeDetails", division.CheckDist);
        //}
        [HttpPost]
        public ActionResult AddHSUREmployeeDetails(AEmployeeDetailVM emp)
        {
            mainrepository.SaveUREmployee(emp);
            return Redirect("HSURIndex");

        }


        public ActionResult AURIndex()
        {
            int appid = 1;
            ViewBag.AppId = appid;
            ViewBag.UType = Session["utype"];
            ViewBag.HSuserid = Session["Id"];
            return View();


        }

    }
}