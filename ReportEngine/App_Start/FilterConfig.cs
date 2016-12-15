using System.Web.Mvc;

namespace ReportEngine
{
    public class FilterConfig : IConfiguratorTask
    {
        private GlobalFilterCollection _filter;

        public void Execute()
        {
            _filter.Add(new HandleErrorAttribute());
        }

        public FilterConfig() : this(GlobalFilters.Filters)
        {

        }

        public FilterConfig(GlobalFilterCollection filters)
        {
            _filter = filters;
        }
    }
}