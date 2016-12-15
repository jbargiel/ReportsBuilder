﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ReportEngine
{
    public class WebApiConfig : IConfiguratorTask
    {
        private readonly HttpConfiguration _config;

        public WebApiConfig()
            : this(GlobalConfiguration.Configuration)
        {

        }

        public WebApiConfig(HttpConfiguration config)
        {
            _config = config;
        }

        public void Execute()
        {
            _config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
