using Admin.Api255;
using Admin.Web46;
using Auth.Data;
using Billing.Processors259;
using Common.Events;
using Documents.Data68;
using Export.Client13;
using Export.Web;
using GalaxyWorks.Models219;
using Import.Service429;
using Integration.Contracts290;
using Logging.Core159;
using Reporting.Shared394;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts;
using Workflow.Contracts330;
using Workflow.Web;

namespace Export.Models
{
    internal interface IExport_Models_Repository11
    {
        /// <summary>Processes the Export_Models_Repository11 operation.</summary>
        void ProcessExport_Models_Repository11();

        /// <summary>Validates the Export_Models_Repository11 state.</summary>
        bool ValidateExport_Models_Repository11();
    }

}