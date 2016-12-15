using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Features.ResolveAnything;
using System.Text;
using System.Threading.Tasks;

namespace Schwab.Report.Common
{
    public static class AppComposer
    {
        public static IContainer Container { get; private set; }

        /// <summary>
        /// Composes application out of individual components.
        /// </summary>
        /// <param name="dependencyProviders">Component dependency providers.</param>
        /// <returns></returns>
        public static IContainer Build(params DependencyProvider[] dependencyProviders)
        {
            Container = Compose(dependencyProviders).Build();
            return Container;
        }

        /// <summary>
        /// Composes application out of individual components.
        /// </summary>
        /// <param name="builder">Component dependency providers.</param>
        /// <returns></returns>
        public static IContainer Build(ContainerBuilder builder)
        {
            Container = builder.Build();
            return Container;
        }

        /// <summary>
        /// Composes application out of individual components.
        /// </summary>
        /// <param name="dependencyProviders">Component dependency providers.</param>
        /// <returns></returns>
        public static ContainerBuilder Compose(IEnumerable<DependencyProvider> dependencyProviders)
        {
            var collection = dependencyProviders as List<DependencyProvider> ?? dependencyProviders.ToList();

            var included = new HashSet<DependencyProvider>(collection);
            var includedTypes = new HashSet<Type>(collection.Select(x => x.GetType()));
            var currentWorkingSet = new List<DependencyProvider>(collection);

            while (true)
            {
                var candidates = currentWorkingSet.SelectMany(x => x.GetDependencies());
                var typesToBeAdded = candidates.Where(x => !includedTypes.Contains(x)).Distinct().ToList();
                if (typesToBeAdded.Any() == false)
                    break;

                currentWorkingSet.Clear();
                foreach (var type in typesToBeAdded)
                {
                    includedTypes.Add(type);
                    var instance = CreateInstance(type);
                    included.Add(instance);
                    currentWorkingSet.Add(instance);
                }
            }

            return BuildContainer(included);
        }

        private static ContainerBuilder BuildContainer(IEnumerable<DependencyProvider> dependencyProviders)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            foreach (var dependencyProvider in dependencyProviders)
            {
                dependencyProvider.PrepareContainer(containerBuilder);
            }
            return containerBuilder;
        }

        private static DependencyProvider CreateInstance(Type type)
        {
            return (DependencyProvider)Activator.CreateInstance(type);
        }
    }
}
