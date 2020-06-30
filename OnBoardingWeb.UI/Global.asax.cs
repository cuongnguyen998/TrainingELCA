using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace OnBoardingWeb.UI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["langCookie"];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cookie.Value);
            }
        }
    }
}