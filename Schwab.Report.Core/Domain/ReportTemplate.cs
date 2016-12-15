using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schwab.Report.Core.Domain
{
    public class ReportTemplate : IEntity<Guid>
    {
        private Guid _id = Guid.NewGuid();

        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public string Name { get; set; }
    }
}
