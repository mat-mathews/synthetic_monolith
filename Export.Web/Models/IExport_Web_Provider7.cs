using Admin.Api;
using Admin.Handlers447;
using Admin.Web4;
using Common.Mappers;
using Documents.Data;
using Export.Validators;
using GalaxyWorks.Core;
using Imaging.Validators;
using Integration.Events;
using Logging.Data29;
using Logging.Shared315;
using Logging.Web;
using Notifications.Mappers110;
using Notifications.Models466;
using Portal.Service378;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web;

namespace Export.Web
{
    internal interface IExport_Web_Provider7
    {
        /// <summary>Processes the Export_Web_Provider7 operation.</summary>
        void ProcessExport_Web_Provider7();

        /// <summary>Validates the Export_Web_Provider7 state.</summary>
        bool ValidateExport_Web_Provider7();
    }

}