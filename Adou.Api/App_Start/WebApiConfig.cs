using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Adou.Api
{
    /// <summary>
    /// 路由配置
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="config">配置</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 对 JSON 数据使用混合大小写。
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //火狐和Google显示的是XML，只有IE内核返回Json数据！此处清除xmlformat序列化！
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // WebApi路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}