using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Schwab.Report.Common
{
    /// <summary>
    /// Configures DI container for specific feature.
    /// </summary>
    public abstract class DependencyProvider
    {
        /// <summary>
        /// Configures DI container for specific feature.
        /// </summary>
        /// <param name="container"></param>
        public abstract void PrepareContainer(ContainerBuilder container);

        /// <summary>
        /// Returns a list of types of <see cref="DependencyProvider"/>s this one depends on.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Type> GetDependencies()
        {
            yield break;
        }
    }
}
