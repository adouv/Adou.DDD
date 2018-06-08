using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Adou.Api.Controllers
{
    /// <summary>
    /// 自定义控制器选择类
    /// </summary>
    public class ApiControllerSelector: DefaultHttpControllerSelector
    {
        private const string NamespaceRouteVariableName = "namespaces";
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<ConcurrentDictionary<string, Type>> _apiControllerCache;

        public ApiControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            _configuration = configuration;
            _apiControllerCache = new Lazy<ConcurrentDictionary<string, Type>>(
                new Func<ConcurrentDictionary<string, Type>>(InitializeApiControllerCache));
        }
        /// <summary>
        /// 初始化Api控制器缓存
        /// </summary>
        /// <returns>ConcurrentDictionary<string, Type></returns>
        private ConcurrentDictionary<string, Type> InitializeApiControllerCache()
        {
            IAssembliesResolver assembliesResolver = this._configuration.Services.GetAssembliesResolver();
            var types = this._configuration.Services.GetHttpControllerTypeResolver()
                .GetControllerTypes(assembliesResolver).ToDictionary(t => t.FullName, t => t);

            return new ConcurrentDictionary<string, Type>(types);
        }
        /// <summary>
        /// 获取控制器名称
        /// </summary>
        /// <param name="request">HTTP 请求消息</param>
        /// <param name="controllerName">控制器名称</param>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> GetControllerFullName(HttpRequestMessage request, string controllerName)
        {
            object namespaceName;
            var data = request.GetRouteData();
            IEnumerable<string> keys = _apiControllerCache.Value.ToDictionary<KeyValuePair<string, Type>, string, Type>(t => t.Key,
                    t => t.Value, StringComparer.CurrentCultureIgnoreCase).Keys.ToList();

            if (!data.Values.TryGetValue(NamespaceRouteVariableName, out namespaceName))
            {
                return from k in keys
                       where k.EndsWith(string.Format(".{0}{1}", controllerName,
                       DefaultHttpControllerSelector.ControllerSuffix), StringComparison.CurrentCultureIgnoreCase)
                       select k;
            }

            string[] namespaces = (string[])namespaceName;
            return from n in namespaces
                   join k in keys on string.Format("{0}.{1}{2}", n, controllerName,
                   DefaultHttpControllerSelector.ControllerSuffix).ToLower() equals k.ToLower()
                   select k;
        }
        /// <summary>
        /// 为指定的HTTP请求选择控制器描述
        /// </summary>
        /// <param name="request">HTTP 请求消息</param>
        /// <returns>HttpControllerDescriptor</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            Type type;
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            string controllerName = this.GetControllerName(request);
            if (string.IsNullOrEmpty(controllerName))
            {
                throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound,
                    string.Format("无法通过API路由匹配到您所请求的URI ‘{0}‘",
                    new object[] { request.RequestUri })));
            }
            IEnumerable<string> fullNames = GetControllerFullName(request, controllerName);
            if (fullNames.Count() == 0)
            {
                throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound,
                        string.Format("无法通过API路由匹配到您所请求的URI ‘{0}‘",
                        new object[] { request.RequestUri })));
            }

            if (this._apiControllerCache.Value.TryGetValue(fullNames.First(), out type))
            {
                return new HttpControllerDescriptor(_configuration, controllerName, type);
            }
            throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound,
                string.Format("无法通过API路由匹配到您所请求的URI ‘{0}‘",
                new object[] { request.RequestUri })));
        }

    }
}
