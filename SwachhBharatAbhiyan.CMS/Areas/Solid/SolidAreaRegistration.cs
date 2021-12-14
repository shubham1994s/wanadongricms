using System.Web.Mvc;

namespace SwachhBharatAbhiyan.CMS.Areas.Solid
{
    public class SolidAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Solid";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Solid_default",
                "Solid/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}