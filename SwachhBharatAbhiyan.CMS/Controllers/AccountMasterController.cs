using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SwachhBharatAbhiyan.CMS.Models;
using SwachBharat.CMS.Bll.Services.Support;
using SwachhBharatAbhiyan.CMS.Models.SessionHelper;
using SwachBharat.CMS.Bll.Repository.MainRepository;
using SwachBharat.CMS.Bll.ViewModels;
using System.Web.Security;
using SwachBharat.CMS.Bll.ViewModels.MainModel;
using SwachBharat.CMS.Bll.ViewModels.ChildModel.Model;
using System.Collections.Generic;

namespace SwachhBharatAbhiyan.CMS.Controllers
{
    public class AccountMasterController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IMainRepository mainrepository;


        public AccountMasterController()
        {
            // AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            mainrepository = new MainRepository();
        }

        public AccountMasterController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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

                //if (!ModelState.IsValid)
                //{
                //    return View(model);
                //}

            
                //   LoginViewModel Result= new LoginViewModel();
                EmployeeVM Result = new EmployeeVM();
                Result.ADUM_LOGIN_ID = model.Email;
                Result.ADUM_PASSWORD = model.Password;
                Result = mainrepository.LoginMaster(Result);
                //var UserDetails = await UserManager.FindAsync(model.Email, model.Password);
                switch (Result.status)
                {
                    case "Success":

                        Session["status"] = "Success";
                        TempData["status"] = "Success";
                        TempData["ADUM_USER_NAME"] = Result.ADUM_USER_NAME;
                        //AddSessionStreet(Result.ADUM_USER_CODE.ToString(), Result.AD_USER_TYPE_ID.ToString(), Result.ADUM_LOGIN_ID, Result.ADUM_USER_NAME, Result.APP_ID.ToString());
                        Session["UserID"] = Result.ADUM_USER_CODE.ToString();
                        Session["LoginId"] = Result.ADUM_LOGIN_ID.ToString();
                        Session["UserProfile"] = Result;
                        return RedirectToAction("MenuIndex");

                    case "LockedOut":
                        return View("Lockout");
                    case "RequiresVerification":

                    case "Failure":
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);

                }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        public ActionResult MenuIndex()
        {
            string loginId =
                (string)Session["LoginId"];
            if (string.IsNullOrEmpty(loginId))
            {
                return RedirectToAction("login");

            }
            else
            {
                List<MenuItemULB> menuList = GetULBMenus(loginId);
                return View("MenuIndex", menuList);

            }
            
        }

        public List<MenuItemULB> GetULBMenus(string loginId)
        {
            List<MenuItemULB> menuList = new List<MenuItemULB>();
            menuList = mainrepository.GetULBMenus(loginId);
            return menuList;
        }
    }
}