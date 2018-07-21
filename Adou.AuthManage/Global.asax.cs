using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Net.Http.Formatting;
using System.Reflection;


namespace Adou.AuthManage
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region AutoFac Ioc(容器) 注入
            var autofac = new ContainerBuilder();
            autofac.RegisterModule(new AutofacModule());
            autofac.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            autofac.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            IContainer container = autofac.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion
        }
    }
}
