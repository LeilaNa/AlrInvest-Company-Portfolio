using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlrInvestSupply
{
    public class MultiLanguageAttribute : FilterAttribute, IActionFilter
    {
        private static string _cookieLangName = "LangForMultiLanguageDemo";
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string cultureOnCookie = GetCultureOnCookie(filterContext.HttpContext.Request);
            string cultureOnURL = filterContext.RouteData.Values.ContainsKey("lang")
                ? filterContext.RouteData.Values["lang"].ToString()
                : Extension.DefaultCulture;
            string culture = cultureOnURL;
            if (string.IsNullOrWhiteSpace(culture))
            {
                culture = (cultureOnCookie == string.Empty)
                ? (filterContext.RouteData.Values["lang"].ToString())
                : cultureOnCookie;

            }
            if (cultureOnURL != culture)
            {
                filterContext.HttpContext.Response.RedirectToRoute("LocalizedDefault",
                new
                {
                    lang = culture,
                    controller = filterContext.RouteData.Values["controller"],
                    action = filterContext.RouteData.Values["action"]
                });
                return;
            }


            HttpCookie langCookie = new HttpCookie(_cookieLangName);
            langCookie.Expires = DateTime.Now.AddMonths(1);
            langCookie.Value = culture;
            filterContext.HttpContext.Response.Cookies.Add(langCookie);


            SetCurrentCultureOnThread(culture);

            if (culture != MultiLanguageViewEngine.CurrentCulture)
            {
                (ViewEngines.Engines[0] as MultiLanguageViewEngine).SetCurrentCulture(culture);
            }



        }

        private static void SetCurrentCultureOnThread(string lang)
        {
            if (string.IsNullOrEmpty(lang))
                lang = Extension.DefaultCulture;

            var cultureInfo = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        public static String GetCultureOnCookie(HttpRequestBase request)
        {
            var cookie = request.Cookies[_cookieLangName];
            string culture = string.Empty;
            if (cookie != null)
            {
                culture = cookie.Value;
            }
            return culture;
        }
    }
}