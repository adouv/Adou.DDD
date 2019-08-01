using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Autofac;

namespace Adou.AuthManage
{
    public class AutofacModule : Autofac.Module
    {
        /// <summary>
        /// 加载注入
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //PetaPoco仓储注入
            var Adou_Repositories_PetaPoco = Assembly.Load(new AssemblyName("Adou.Repositories.PetaPoco"));
            builder.RegisterAssemblyTypes(Adou_Repositories_PetaPoco)
                .Where(t => t.Name.EndsWith("Rep"))
                .AsSelf()
                .PropertiesAutowired();
            //服务注入
            var Adou_Api_Service = Assembly.Load(new AssemblyName("Adou.Api.Service"));
            builder.RegisterAssemblyTypes(Adou_Api_Service)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .AsSelf()
                .PropertiesAutowired();
            //实体注入
            var Adou_Api_Model = Assembly.Load(new AssemblyName("Adou.Api.Model"));
            builder.RegisterAssemblyTypes(Adou_Api_Model)
                .Where(t => t.Name.EndsWith("Model"))
                .AsSelf()
                .PropertiesAutowired();
            //控制器注入
            var Adou_Api_Controllers = Assembly.Load(new AssemblyName("Adou.Api.Controllers"));
            builder.RegisterAssemblyTypes(Adou_Api_Controllers)
                .Where(t => t.Name.EndsWith("Controller"))
                .AsSelf()
                .PropertiesAutowired();
        }
    }
}