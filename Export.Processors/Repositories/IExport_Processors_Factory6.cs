using Admin.Tests10;
using Auth.Contracts;
using Auth.Data;
using BatchJobs.Handlers443;
using Documents.Service;
using Imaging.Events424;
using Import.Handlers;
using Integration.Contracts290;
using Integration.Shared;
using Logging.Contracts373;
using Portal.Api51;
using Scheduling.Models441;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;
using Utilities.Models;
using Workflow.Validators201;

namespace Export.Processors
{
    public interface IExport_Processors_Factory6
    {
        /// <summary>Processes the Export_Processors_Factory6 operation.</summary>
        void ProcessExport_Processors_Factory6();

        /// <summary>Validates the Export_Processors_Factory6 state.</summary>
        bool ValidateExport_Processors_Factory6();
    }

}