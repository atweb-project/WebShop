using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebShop.Models;
using WebShop.Services.Mapping;

namespace WebShop
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var globalMappings = new GlobalMappings(new MappingTypes());
            globalMappings.Initialize();

            ModelBinderProviders.BinderProviders.Clear();
            ModelBinderProviders.BinderProviders.Add(new CustomModelBinderProvider());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                Exception ex = Server.GetLastError();

                if (Response.StatusCode != 404)
                {
                    //Logging.Error("Caught in Global.asax", ex);
                }
            }
        }
    }
}
