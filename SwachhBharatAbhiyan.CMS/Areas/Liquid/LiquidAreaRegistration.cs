using System.Web.Mvc;

namespace SwachhBharatAbhiyan.CMS.Areas.Liquid
{
    public class LiquidAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Liquid";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Liquid_default",
                "Liquid/{controller}/{action}/{id}",
                new {action = "Index", id = "" },
                new { controller = "LiquidHome|LiquidWaste|LiquidEmployee|LiquidAttendence|LiquidGarbage|LiquidAndroid|LiquidAccount" },
               new[] { "SwachhBharatAbhiyan.CMS.Areas.Liquid.Controllers" }
            );
        }
    }
}