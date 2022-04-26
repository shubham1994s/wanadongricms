
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

        public AEmployeeDetailVM GetDivision()
        {
            return mainService.GetDivision();

        }
        public AEmployeeDetailVM GetAUREmployeeDetails(int teamId)
        {
            return mainService.GetAUREmployeeDetails(teamId);

        }

        public AEmployeeDetailVM GetDistrict(int id)
        {
            return mainService.GetDistrict(id);

        }

        public void SaveUREmployee(AEmployeeDetailVM employee)
        {
            mainService.SaveUREmployeeDetails(employee);

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

        public EmployeeVM LoginMaster(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appUser = (db.AEmployeeMasters.Where(x => x.LoginId == _userinfo.ADUM_LOGIN_ID && x.Password == _userinfo.ADUM_PASSWORD).SingleOrDefault());
                if (appUser != null)
                {
                    _EmployeeVM.ADUM_LOGIN_ID = appUser.LoginId;

                    //_EmployeeVM.APP_ID = appUser.APP_ID;
                    _EmployeeVM.ADUM_USER_NAME = appUser.EmpName;
                    _EmployeeVM.ADUM_USER_CODE = Convert.ToInt32(appUser.EmpId);
                    _EmployeeVM.ADUM_DESIGNATION = appUser.type;
                    _EmployeeVM.ADUM_PASSWORD = appUser.Password;
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
                var appUser = (db.EmployeeMasters.Where(x => x.LoginId == _userinfo.ADUM_LOGIN_ID && x.Password == _userinfo.ADUM_PASSWORD && x.isActive == true).SingleOrDefault());
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

            menuList.Add(new MenuItem { M_ID = 1, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Waste Collection", returnUrl = "", Type = "W", isActive = true });
            menuList.Add(new MenuItem { M_ID = 2, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Liquid Collection", returnUrl = "", Type = "L", isActive = true });
            menuList.Add(new MenuItem { M_ID = 3, M_P_ID = 0, ActionName = "", ControllerName = "", LinkText = "Street Collection", returnUrl = "", Type = "S", isActive = true });

            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {

                var W = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                    (a, b) => new { AppId = a.AppId, AppName = b.AppName, IsActive = b.IsActive })
                    .Join(db.UserInApps, c => c.AppId, d => d.AppId,
                    (c, d) => new { c, d })
                    .Join(db.AspNetUsers, e => e.d.UserId, f => f.Id,
                    (e, f) => new MenuItem { M_ID = 1, M_P_ID = 1, ActionName = "Login", ControllerName = "Account", LinkText = e.c.AppName, returnUrl = f.UserName, Type = "W", isActive = e.c.IsActive }).Where(x => x.isActive == true).ToList();

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

            return menuList.Where(a => !(a.LinkText.ToUpper().Contains("THANE"))).ToList();
        }

        public class Division
        {
            public int divisionId { get; set; }
            public string divisionName { get; set; }

        }
        public class District
        {
            public int districtId { get; set; }
            public int divisionId { get; set; }
            public string districtName { get; set; }

        }

        public List<MenuItemULB> GetULBMenus1()
        {
            List<int> AppList = new List<int> { 3047 };
            List<MenuItemULB> menuList = new List<MenuItemULB>();
            List<Division> divisionList = new List<Division> {
                                                               new Division {divisionId = 1,divisionName= "Other" },
                                                               new Division {divisionId = 2,divisionName= "Nagpur" }
                                                             };
            List<District> districtList = new List<District> {
                                                                 new District{ divisionId = 2,districtId = 1,districtName = "Nagpur"},
                                                                 new District{ divisionId = 2,districtId = 2,districtName = "Gadchiroli"},
                                                                 new District{ divisionId = 1,districtId = 2,districtName = "Other"},
                                                              };
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appListDivision = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.Tehsil })
                    .Where(c => AppList.Contains(c.AppId))
                    .GroupBy(c => c.Devision)
                    .Select(group => group.FirstOrDefault()).ToList();
                if (appListDivision != null && appListDivision.Count > 0)
                {
                    foreach (var appDiv in appListDivision)
                    {

                        var div = divisionList.Where(a => a.divisionId == appDiv.Devision)
                            .Select(b => new MenuItemULB { divisionId = b.divisionId, districtId = 0, ULBId = 0, LinkText = b.divisionName, ActionName = "", ControllerName = "", returnUrl = "", Type = "W" })
                            .FirstOrDefault();
                        if (div != null)
                        {
                            menuList.Add(div);

                            var appListDistrict = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.Tehsil, District = b.District })
                            .Where(c => AppList.Contains(c.AppId))
                            .Where(c => c.Devision == appDiv.Devision)
                            .GroupBy(c => c.District)
                            .Select(group => group.FirstOrDefault()).ToList();

                            if (appListDistrict != null && appListDistrict.Count > 0)
                            {
                                foreach (var appDist in appListDistrict)
                                {
                                    var dist = districtList.Where(a => a.divisionId == appDiv.Devision && a.districtId == appDist.District)
                                        .Select(b => new MenuItemULB { divisionId = b.divisionId, districtId = b.districtId, ULBId = 0, LinkText = b.districtName, ActionName = "", ControllerName = "", returnUrl = "", Type = "W" })
                                        .FirstOrDefault();
                                    if (dist != null)
                                    {
                                        menuList.Add(dist);

                                        var ulb = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                                                (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.Tehsil, District = b.District })
                                                .Where(c => AppList.Contains(c.AppId))
                                                .Where(c => c.Devision == appDiv.Devision && c.District == appDist.District)
                                                .Join(db.UserInApps, c => c.AppId, d => d.AppId,
                                                (c, d) => new { c, d })
                                                .Join(db.AspNetUsers, e => e.d.UserId, f => f.Id,
                                                (e, f) => new MenuItemULB { divisionId = e.c.Devision, districtId = e.c.District, ULBId = e.c.AppId, LinkText = e.c.AppName, ActionName = "Login", ControllerName = "Account", returnUrl = f.UserName, Type = "W" }).ToList();
                                        if (ulb != null && ulb.Count > 0)
                                        {
                                            menuList.AddRange(ulb);

                                        }


                                    }


                                }
                            }

                        }




                    }
                }

            }


            return menuList;
        }

        public List<MenuItemULB> GetULBMenus2(string loginId)
        {

            List<int> AppList = new List<int>();
            List<MenuItemULB> menuList = new List<MenuItemULB>();
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appUser = db.AEmployeeMasters.Where(a => a.LoginId == loginId).FirstOrDefault();
                if (appUser != null)
                {
                    //if(!(appUser.DivisionId == null || appUser.DivisionId == 0))
                    //{
                    //    if (!(appUser.DistictId == null || appUser.DistictId == 0))
                    //    {
                    //        AppList = db.AppDetails.Where(a => a.District == appUser.DivisionId && a.Tehsil == appUser.DistictId).Select(a => a.AppId).ToList();
                    //    }
                    //    else
                    //    {
                    //        AppList = db.AppDetails.Where(a => a.District == appUser.DivisionId).Select(a => a.AppId).ToList();

                    //    }
                    //}
                    //else if(!(appUser.DistictId == null || appUser.DistictId == 0))
                    //{
                    //    AppList = db.AppDetails.Where(a => a.Tehsil == appUser.DistictId).Select(a => a.AppId).ToList();

                    //}
                    //else
                    //{
                    //    AppList = db.AppDetails.Select(a => a.AppId).ToList();

                    //}
                    if (appUser.type == "A")
                    {
                        AppList = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => a.AppId).ToList();
                    }
                    else
                    {
                        AppList = appUser.isActiveULB.Split(',').Select(x => Convert.ToInt32(x)).ToList();
                    }

                    var appListDivision = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.District })
                       .Where(c => AppList.Contains(c.AppId))
                       .GroupBy(c => c.Devision)
                       .Select(group => group.FirstOrDefault()).ToList();
                    if (appListDivision != null && appListDivision.Count > 0)
                    {
                        foreach (var appDiv in appListDivision)
                        {

                            var div = db.state_districts.Where(a => a.id == appDiv.Devision)
                                .Select(b => new MenuItemULB { divisionId = b.id, districtId = 0, ULBId = 0, LinkText = b.district_name, ActionName = "", ControllerName = "", returnUrl = "", Type = "W" })
                                .FirstOrDefault();
                            if (div != null)
                            {
                                menuList.Add(div);

                                var appListDistrict = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.District, District = b.Tehsil })
                                .Where(c => AppList.Contains(c.AppId))
                                .Where(c => c.Devision == appDiv.Devision)
                                .GroupBy(c => c.District)
                                .Select(group => group.FirstOrDefault()).ToList();

                                if (appListDistrict != null && appListDistrict.Count > 0)
                                {
                                    foreach (var appDist in appListDistrict)
                                    {
                                        var dist = db.tehsils.Where(a => a.id == appDist.District)
                                            .Select(b => new MenuItemULB { divisionId = appDiv.Devision, districtId = b.id, ULBId = 0, LinkText = b.name, ActionName = "", ControllerName = "", returnUrl = "", Type = "W" })
                                            .FirstOrDefault();
                                        if (dist != null)
                                        {
                                            menuList.Add(dist);

                                            var ulb = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                                                    (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.District, District = b.Tehsil })
                                                    .Where(c => AppList.Contains(c.AppId))
                                                    .Where(c => c.Devision == appDiv.Devision && c.District == appDist.District)
                                                    .Join(db.UserInApps, c => c.AppId, d => d.AppId,
                                                    (c, d) => new { c, d })
                                                    .Join(db.AspNetUsers, e => e.d.UserId, f => f.Id,
                                                    (e, f) => new MenuItemULB { divisionId = e.c.Devision, districtId = e.c.District, ULBId = e.c.AppId, LinkText = e.c.AppName, ActionName = "Login", ControllerName = "Account", returnUrl = f.UserName, Type = "W" }).ToList();
                                            if (ulb != null && ulb.Count > 0)
                                            {
                                                menuList.AddRange(ulb);

                                            }


                                        }


                                    }
                                }

                            }




                        }
                    }

                }

            }


            return menuList;
        }

        public List<MenuItemULB> GetULBMenus(string loginId)
        {

            List<int> AppList = new List<int>();
            List<MenuItemULB> menuList = new List<MenuItemULB>();
            using (DevSwachhBharatMainEntities db = new DevSwachhBharatMainEntities())
            {
                var appUser = db.AEmployeeMasters.Where(a => a.LoginId == loginId).FirstOrDefault();
                if (appUser != null)
                {

                    if (appUser.type == "A")
                    {
                        AppList = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => a.AppId).ToList();
                    }
                    else
                    {
                        AppList = appUser.isActiveULB.Split(',').Select(x => Convert.ToInt32(x)).ToList();
                    }

                    var appListDivision = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { a, b })
                        .Join(db.state_districts, c => c.b.District, d => d.id, (c, d) => new { c, d })
                       .Where(e => AppList.Contains(e.c.a.AppId))
                       .GroupBy(f => f.c.b.District)
                       .Select(group => group.FirstOrDefault())
                       .OrderBy(g => g.d.district_name)
                       .Select(g => new MenuItemULB { divisionId = g.d.id, districtId = 0, ULBId = 0, LinkText = g.d.district_name, ActionName = "", ControllerName = "", returnUrl = "", Type = "W" })
                       .ToList();
                    if (appListDivision != null && appListDivision.Count > 0)
                    {
                        foreach (var appDiv in appListDivision)
                        {
                            menuList.Add(appDiv);

                            var appListDistrict = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId, (a, b) => new { a, b })
                            .Join(db.tehsils, c => c.b.Tehsil, d => d.id, (c, d) => new { c, d })
                            .Where(e => AppList.Contains(e.c.a.AppId))
                            .Where(f => f.c.b.District == appDiv.divisionId)
                            .GroupBy(g => g.c.b.Tehsil)
                            .Select(group => group.FirstOrDefault())
                            .OrderBy(g => g.d.name)
                            .Select(g => new MenuItemULB { divisionId = appDiv.divisionId, districtId = g.d.id, ULBId = 0, LinkText = g.d.name, ActionName = "", ControllerName = "", returnUrl = "", Type = "W" })
                            .ToList();

                            if (appListDistrict != null && appListDistrict.Count > 0)
                            {
                                foreach (var appDist in appListDistrict)
                                {

                                    menuList.Add(appDist);

                                    var ulb = db.AppConnections.Join(db.AppDetails, a => a.AppId, b => b.AppId,
                                            (a, b) => new { AppId = a.AppId, AppName = b.AppName, Devision = b.District, District = b.Tehsil })
                                            .Where(c => AppList.Contains(c.AppId))
                                            .Where(c => c.Devision == appDiv.divisionId && c.District == appDist.districtId)
                                            .Join(db.UserInApps, c => c.AppId, d => d.AppId,
                                            (c, d) => new { c, d })
                                            .Join(db.AspNetUsers, e => e.d.UserId, f => f.Id,
                                            (e, f) => new MenuItemULB { divisionId = e.c.Devision, districtId = e.c.District, ULBId = e.c.AppId, LinkText = e.c.AppName, ActionName = "Login", ControllerName = "Account", returnUrl = f.UserName, Type = "W" })
                                            .OrderBy(m => m.LinkText)
                                            .ToList();
                                    if (ulb != null && ulb.Count > 0)
                                    {
                                        menuList.AddRange(ulb);

                                    }

                                }
                            }

                        }
                    }

                }

            }


            return menuList;
        }


        //Addedv By Saurabh (27 May 2019)
        public List<AppDetail> GetAppName()
        {
            return mainService.GetAppName();
        }

        public List<AppDetail> GetURAppName(string utype, string LoginId, string Password)
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
