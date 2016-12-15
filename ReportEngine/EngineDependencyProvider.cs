using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;
using Autofac.Integration.WebApi;

using Schwab.Report.Data;

using Schwab.Report.Common;

namespace ReportEngine
{
    public class EngineDependencyProvider : DependencyProvider
    {
        public override void PrepareContainer(ContainerBuilder container)
        {
            container.RegisterApiControllers(Assembly.GetExecutingAssembly());

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(
                t => typeof(IConfiguratorTask).IsAssignableFrom(t)).AsImplementedInterfaces().UsingConstructor();
        }

        public override IEnumerable<Type> GetDependencies()
        {
            return new List<Type>
            {
                  typeof(RepositoryDependencyProvider)
            };
        }
    }
}