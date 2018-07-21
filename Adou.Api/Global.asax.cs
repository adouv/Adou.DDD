using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Adou.Api
{
    /// <summary>
    /// 全局配置
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 启动程序
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region AutoFac容器注入
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
