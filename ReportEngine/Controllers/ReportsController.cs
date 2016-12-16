using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Schwab.Report.Core.Domain;
using Schwab.Report.Core;

namespace ReportEngine.Controllers
{
    public class ReportsController : ApiController
    {
        IReportTemplateRepository _reportTemplateRepository;

        public ReportsController(IReportTemplateRepository reportTemplateRepository)
        {
            if (reportTemplateRepository == null)
                throw new NullReferenceException("reportTemplateRepository");

            _reportTemplateRepository = reportTemplateRepository;
        }

        public ReportTemplate Get(Guid id)
        {
            return _reportTemplateRepository.GetRepositoryById(id);
        }

        public void Post([FromBody]string value)
        {

        }

        public void Put(int id, [FromBody]string value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}