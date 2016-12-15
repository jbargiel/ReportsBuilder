using System;
using System.Collections.Generic;
using Schwab.Report.Common;
using Autofac;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ReportEngine
{
    public class Configurator
    {
        static Configurator()
        {
            ConfigureContainer();
        }

        public static void Run()
        {
            var tasks = AppComposer.Container.Resolve<IEnumerable<IConfiguratorTask>>();


            foreach (var task in tasks)
            {
                task.Execute();
            }
        }

        private static void ConfigureContainer()
        {
            var configuration = GlobalConfiguration.Configuration;

            var builder = AppComposer.Compose(new[] { new EngineDependencyProvider() });

            builder.RegisterWebApiFilterProvider(configuration);

            AppComposer.Build(builder);

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(AppComposer.Container);
        }
    }
}