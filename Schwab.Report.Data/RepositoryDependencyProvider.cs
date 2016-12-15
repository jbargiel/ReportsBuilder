using System.Reflection;
using Autofac;

using Schwab.Report.Common;

namespace Schwab.Report.Data
{
    public class RepositoryDependencyProvider : DependencyProvider
    {
        public override void PrepareContainer(ContainerBuilder container)
        {
            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                     .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            container.RegisterType<JsonSerializer>().As<IJsonSerializer>();
        }
    }
}