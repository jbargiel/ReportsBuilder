using System;

using Schwab.Report.Core;
using Schwab.Report.Core.Domain;

namespace Schwab.Report.Data.Mongo
{
    public class ReportTemplateRepository : RepositoryBase<ReportTemplate>, IReportTemplateRepository 
    {
        public ReportTemplate GetRepositoryById(Guid id)
        {
            return GetById(id);
        }
    }
}
