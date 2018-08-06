using BZ.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //验证恶意字符
            string msg = "{\"type\":0,\"message\":\"您提交的数据有恶意字符,请检查确认！\"}";
            if (Request.Cookies != null)
            {
                if (WebSafe.IsCookieData())
                {
                    Response.Write(msg);
                    Response.End();
                }
            }

            if (Request.UrlReferrer != null)
            {
                if (WebSafe.IsReferer())
                {
                    Response.Write(msg);
                    Response.End();
                }
            }

            if (Request.RequestType.ToUpper() == "POST")
            {
                if (WebSafe.IsPostData())
                {
                    Response.Write(msg);
                    Response.End();
                }
            }
            if (Request.RequestType.ToUpper() == "GET")
            {
                if (WebSafe.IsGetData())
                {
                    Response.Write(msg);
                    Response.End();
                }
            }

        }
    }
}
