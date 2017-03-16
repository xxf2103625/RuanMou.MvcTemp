using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Configuration;
using RuanMou.Interface;
using RuanMou.Repository;
using Autofac.Integration.Mvc;
using System.Reflection;

namespace RuanMou.MvcTemp
{
    /// <summary>
    /// Aotufac配置
    /// </summary>
    public class AotufacConfig
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();
            //重写控制器工厂方法实现对象的释放(重要)
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register individual components
            //builder.RegisterInstance(new UserRepository())
            //       .As<IUserRepository>();

            //保证每个请求单例
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

            //有了控制器工厂重写就不需要这个
            //builder.RegisterType<TaskController>();

            //builder.Register(c => new LogManager(DateTime.Now)) 
            //       .As<ILogger>();

            ///配置文件注册 高版本调用方法不一样了?
            //builder.RegisterModule(new ConfigurationSettingsReader("mycomponents"));
            //builder.RegisterModule(new ConfigurationModule(configuration: Microsoft.Extensions.Configuration.ConfigurationPath.GetParentPath(""));

            // Scan an assembly for components 程序集内批量注册并过滤
            //builder.RegisterAssemblyTypes(myAssembly)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();

            var container = builder.Build();
        }
    }
}