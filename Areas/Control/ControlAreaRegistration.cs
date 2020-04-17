using System.Web.Mvc;

namespace AlrInvestSupply.Areas.Control
{
    public class ControlAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Control";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //context.MapRoute(
            //    "Control_default",
            //    "Control/{controller}/{action}/{id}",
            //    new {controller="Slogans", action = "Index", id = UrlParameter.Optional }
            //);

            context.MapRoute(
       name: "Control_default",
       url: "Control/{lang}/{controller}/{action}/{id}",
       defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
       constraints: new { lang = "az|en" }
   );

            context.MapRoute(
                name: "Default",
                url: "Control/{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", lang = "az", id = UrlParameter.Optional }
            );

        }
    }
}