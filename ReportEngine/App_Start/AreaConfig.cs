using System.Web.Mvc;

namespace ReportEngine
{
    public class AreaConfig : IConfiguratorTask
    {
        public void Execute()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}