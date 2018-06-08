using System.Web.Mvc;

namespace Adou.AuthManage.Areas.AdouManage
{
    public class AdouManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdouManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdouManage_default",
                "AdouManage/{controller}/{action}/{id}",
                new { controller = "App", action = "Index", id = UrlParameter.Optional },
                new string[] { "Adou.AuthManage.Areas.AdouManage.Controllers" }
            );
        }
    }
}