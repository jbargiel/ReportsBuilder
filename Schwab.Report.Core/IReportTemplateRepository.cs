using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Schwab.Report.Core.Domain;

namespace Schwab.Report.Core
{
    public interface IReportTemplateRepository 
    {
        ReportTemplate GetRepositoryById(Guid id);
    }
}
