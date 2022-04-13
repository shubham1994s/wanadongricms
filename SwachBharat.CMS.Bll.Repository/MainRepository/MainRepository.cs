
using SwachBharat.CMS.Bll.Services;
using SwachBharat.CMS.Bll.ViewModels.ChildModel.Model;
using SwachBharat.CMS.Bll.ViewModels.MainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwachBharat.CMS.Dal.DataContexts;

namespace SwachBharat.CMS.Bll.Repository.MainRepository
{
    public class MainRepository : IMainRepository
    {
        MainService mainService;
        public MainRepository()
        {
            mainService = new MainService();
        }


        #region State
        public AppStateVM GetStateDetailsById(int teamId)
        {
            AppStateVM stateVM = InitBaseViewModel<AppStateVM>();
            stateVM = mainService.GetStateDetailsById(teamId);
            return stateVM;
        }

        public AppStateVM GetStateById(int Id)
        {
            AppStateVM stateVM = InitBaseViewModel<AppStateVM>();
            stateVM = mainService.GetStateDetailsById(Id);
            return stateVM;
        }
        public void SaveState(AppStateVM state)
        {
            mainService.SaveStateDetail(state);
        }

        public void DeleteState(int teamId)
        {
            mainService.DeleteStateRecord(teamId);
        }
        #endregion

        #region District
        public AppDistrictVM GetDistrictById(int teamId)
        {
            return mainService.GetDictrictById(teamId);

        }
        public void SaveDistrict(AppDistrictVM details)
        {
            mainService.SaveDictrictDetails(details);
        }
        public void DeleteDistrict(int teamId)
        {
            mainService.DeleteDictrictRecord(teamId);
        }
        #endregion

        #region Taluka
        public AppTalukaVM GetTalukaById(int teamId, string name)
        {
            return mainService.GetTalukaById(teamId, name);
        }
        public void SaveTaluka(AppTalukaVM state)
        {
            mainService.SaveTalukaDetails(state);
        }
        public void DeleteTaluka(int teamId)
        {
            mainService.DeleteTalukaRecord(teamId);
        }


        #endregion

        public T InitBaseViewModel<T>() where T : BaseVM
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            // obj.languageList = screenService.ListLanguage();
            return obj;
        }

        //public int GetAppIdForApp(string appName)
        //{
        //    return mainService.GetAppIdForApp(appName);
        //}
        //public void SaveApplicationDetails(AppDetailsVM appDetailsVM)
        //{
        //    mainService.SaveApplicationDetails(appDetailsVM);
        //}

        //public IEnumerable<VMApplication> GetAppId()
        //{
        //    return mainService.GetAppId();
        //}
        //public IEnumerable<SubscriptionVM> GetSubscriptionId()
        //{
        //    return mainService.GetSubscriptionId();
        //}
        //public bool AddApptoUser(string UserId, int AppId, int SubscriptionId)
        //{
        //    return mainService.AddApptoUser(UserId, AppId, SubscriptionId);
        //}
        public string GetDatabaseFromAppID(int AppId)
        {
            return mainService.GetDatabaseFromAppID(AppId);
        }
        public AppDetailsVM GetApplicationDetails(int AppId)
        {
            return mainService.GetApplicationDetails(AppId);
        }
        public int GetUserAppId(string UserId)
        {
            return mainService.GetUserAppId(UserId);
        }

        public int GetUserAppIdL(string UserId)
        {
            return mainService.GetUserAppIdL(UserId);
        }

        public int GetUserAppIdSS(string UserId)
        {
            return mainService.GetUserAppIdSS(UserId);
        }
        public EmployeeVM Login(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appUser = (db.AD_USER_MST_LIQUID.Where(x => x.ADUM_LOGIN_ID == _userinfo.ADUM_LOGIN_ID && x.ADUM_PASSWORD == _userinfo.ADUM_PASSWORD).SingleOrDefault());
                if (appUser != null)
                {
                    _EmployeeVM.ADUM_LOGIN_ID = appUser.ADUM_LOGIN_ID;

                    _EmployeeVM.APP_ID = appUser.APP_ID;
                    _EmployeeVM.ADUM_USER_NAME = appUser.ADUM_USER_NAME;
                    _EmployeeVM.ADUM_USER_CODE = Convert.ToInt32(appUser.ADUM_USER_CODE);
                    _EmployeeVM.status = "Success";

                    return _EmployeeVM;
                }
                else
                {
                    _EmployeeVM.status = "Failure";
                    return _EmployeeVM;
                }
            }
        }

        public EmployeeVM LoginStreet(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appUser = (db.AD_USER_MST_STREET.Where(x => x.ADUM_LOGIN_ID == _userinfo.ADUM_LOGIN_ID && x.ADUM_PASSWORD == _userinfo.ADUM_PASSWORD).SingleOrDefault());
                if (appUser != null)
                {
                    _EmployeeVM.ADUM_LOGIN_ID = appUser.ADUM_LOGIN_ID;

                    _EmployeeVM.APP_ID = appUser.APP_ID;
                    _EmployeeVM.ADUM_USER_NAME = appUser.ADUM_USER_NAME;
                    _EmployeeVM.ADUM_USER_CODE = Convert.ToInt32(appUser.ADUM_USER_CODE);
                    _EmployeeVM.status = "Success";

                    return _EmployeeVM;
                }
                else
                {
                    _EmployeeVM.status = "Failure";
                    return _EmployeeVM;
                }
            }
        }

        public EmployeeVM LoginUR(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appUser = (db.EmployeeMasters.Where(x => x.LoginId == _userinfo.ADUM_LOGIN_ID && x.Password == _userinfo.ADUM_PASSWORD && x.isActive==true).SingleOrDefault());
                if (appUser != null)
                {
                    _EmployeeVM.ADUM_LOGIN_ID = appUser.LoginId;
                    _EmployeeVM.ADUM_PASSWORD = appUser.Password;
                    _EmployeeVM.ADUM_DESIGNATION = appUser.type;
                    _EmployeeVM.ADUM_USER_CODE = appUser.EmpId;
                    _EmployeeVM.status = "Success";

                    return _EmployeeVM;
                }
                else
                {
                    _EmployeeVM.status = "Failure";
                    return _EmployeeVM;
                }
            }
        }

        public List<MenuItem> GetMenus1()
        {
            List<MenuItem> menuList = new List<MenuItem>();
            List<MenuItem> menuListW = new List<MenuItem>();
            List<MenuItem> menuListL = new List<MenuItem>();
            List<MenuItem> menuListS = new List<MenuItem>();
            menuListW.Add(new MenuItem { M_ID = 1, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Waste Collection", returnUrl = "", Type = "W" });
            menuListL.Add(new MenuItem { M_ID = 2, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Liquid Collection", returnUrl = "", Type = "L" });
            menuListS.Add(new MenuItem { M_ID = 3, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Street Collection", returnUrl = "", Type = "S" });

            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appList = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { AppId = a.AppId, AppName = b.AppName }).ToList();
                if (appList != null && appList.Count > 0)
                {
                    foreach (var app in appList)
                    {
                        var itemW = db.UserInApps.Join(db.AspNetUsers, a => a.UserId, b => b.Id,
                            (a, b) => new { M_ID = 1, M_P_ID = 1, ActionName = "Login", ControllerName = "Account", LinkText = app.AppName, returnUrl = b.UserName, Type = "W", appId = a.AppId })
                            .Where(c => c.appId == app.AppId)
                            .Select(c => new MenuItem { M_ID = 1, M_P_ID = c.M_P_ID, ActionName = c.ActionName, ControllerName = c.ControllerName, LinkText = c.LinkText, returnUrl = c.returnUrl, Type = c.Type }).FirstOrDefault();
                        if (itemW != null)
                        {
                            menuListW.Add(itemW);
                        }

                        var itemL = db.AD_USER_MST_LIQUID.Select(a => new { M_ID = 1, M_P_ID = 2, ActionName = "Login", ControllerName = "Account", LinkText = app.AppName, returnUrl = a.ADUM_LOGIN_ID, Type = "L", appId = a.APP_ID })
                            .Where(c => c.appId == app.AppId)
                            .Select(c => new MenuItem { M_ID = 1, M_P_ID = c.M_P_ID, ActionName = c.ActionName, ControllerName = c.ControllerName, LinkText = c.LinkText, returnUrl = c.returnUrl, Type = c.Type }).FirstOrDefault();

                        if (itemL != null)
                        {
                            menuListL.Add(itemL);
                        }

                        var itemS = db.AD_USER_MST_STREET.Select(a => new { M_ID = 1, M_P_ID = 3, ActionName = "Login", ControllerName = "Account", LinkText = app.AppName, returnUrl = a.ADUM_LOGIN_ID, Type = "S", appId = a.APP_ID })
                            .Where(c => c.appId == app.AppId)
                            .Select(c => new MenuItem { M_ID = 1, M_P_ID = c.M_P_ID, ActionName = c.ActionName, ControllerName = c.ControllerName, LinkText = c.LinkText, returnUrl = c.returnUrl, Type = c.Type }).FirstOrDefault();

                        if (itemS != null)
                        {
                            menuListS.Add(itemS);
                        }
                    }
                    menuList.AddRange(menuListW.OrderBy(a => a.LinkText));
                    menuList.AddRange(menuListL.OrderBy(a => a.LinkText));
                    menuList.AddRange(menuListS.OrderBy(a => a.LinkText));
                }
            }

            return menuList.Where(a => !(a.LinkText.ToUpper().Contains("THANE"))).ToList();
        }


        //Added by milind 04-03-2022 
        public List<MenuItem> GetMenus()
        {
            List<MenuItem> menuList = new List<MenuItem>();

            menuList.Add(new MenuItem { M_ID = 1, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Waste Collection", returnUrl = "", Type = "W", isActive=true});
            menuList.Add(new MenuItem { M_ID = 2, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Liquid Collection", returnUrl = "", Type = "L", isActive = true });
            menuList.Add(new MenuItem { M_ID = 3, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Street Collection", returnUrl = "", Type = "S", isActive = true });

            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                
                var W = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                    (a, b) => new { AppId = a.AppId, AppName = b.AppName, IsActive = b.IsActive })
                    .Join(db.UserInApps, c => c.AppId, d => d.AppId,
                    (c, d) => new { c, d })
                    .Join(db.AspNetUsers, e => e.d.UserId, f => f.Id,
                    (e, f) => new MenuItem { M_ID = 1, M_P_ID = 1, ActionName = "Login", ControllerName = "Account", LinkText = e.c.AppName, returnUrl = f.UserName, Type = "W",isActive=e.c.IsActive }).Where(x=>x.isActive==true).ToList();

                if (W != null && W.Count > 0)
                {
                    menuList.AddRange(W.OrderBy(a => a.LinkText));
                }

                var L = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                    (a, b) => new { AppId = a.AppId, AppName = b.AppName, IsActive = b.IsActive })
                    .Join(db.AD_USER_MST_LIQUID, c => c.AppId, d => d.APP_ID,
                    (c, d) => new MenuItem { M_ID = 1, M_P_ID = 2, ActionName = "Login", ControllerName = "Account", LinkText = c.AppName, returnUrl = d.ADUM_LOGIN_ID, Type = "L", isActive = c.IsActive }).Where(x => x.isActive == true).ToList();

                if (L != null && L.Count > 0)
                {
                    menuList.AddRange(L.OrderBy(a => a.LinkText));
                }

                var S = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                    (a, b) => new { AppId = a.AppId, AppName = b.AppName, IsActive = b.IsActive })
                    .Join(db.AD_USER_MST_STREET, c => c.AppId, d => d.APP_ID,
                    (c, d) => new MenuItem { M_ID = 1, M_P_ID = 3, ActionName = "Login", ControllerName = "Account", LinkText = c.AppName, returnUrl = d.ADUM_LOGIN_ID, Type = "S", isActive = c.IsActive }).Where(x => x.isActive == true).ToList();

                if (S != null && S.Count > 0)
                {
                    menuList.AddRange(S.OrderBy(a => a.LinkText));
                }

            }

            return menuList.Where(a => !(a.LinkText.ToUpper().Contains("THANE")) ).ToList();
        }

        //Addedv By Saurabh (27 May 2019)
        public List<AppDetail> GetAppName()
        {
            return mainService.GetAppName();
        }

        public List<AppDetail> GetURAppName(string utype, string LoginId,string Password)
        {
            return mainService.GetURAppName(utype, LoginId, Password);
        }

        public string GetLoginid(string LoginId)
        {
            return mainService.GetLoginid(LoginId);
        }
        #region Game
        public List<GameMaster> GetGameList()
        {
            return mainService.GetGameList();
        }

        public List<AppDetail> GetAppList(string utype, string LoginId, string Password)
        {
            return mainService.GetAppList(utype, LoginId, Password);
        }
        public InfotainmentDetailsVW GetInfotainmentDetailsById(int ID)
        {
            return mainService.GetInfotainmentDetailsById(ID);
        }

        public void SaveGameDetails(InfotainmentDetailsVW data)
        {
            if (data.GameDetailsId <= 0)
            {
                data.GameDetailsId = 0;
            }
            mainService.SaveGameDetails(data);
        }

        #endregion

    }
}
