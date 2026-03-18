using Admin.Tests;
using Auth.Api143;
using Auth.Client249;
using BatchJobs.Tests;
using Billing.Api9;
using Billing.Data;
using Common.Models381;
using DataAccess.Models;
using Export.Models461;
using Export.Tests;
using Import.Client7;
using Integration.Client;
using Reporting.Events317;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Workflow.Client351;
using Workflow.Contracts192;
using Workflow.Web;

namespace Export.Web130
{
    public interface IExport_Web130_Factory
    {
        /// <summary>Processes the Export_Web130_Factory operation.</summary>
        void ProcessExport_Web130_Factory();

        /// <summary>Validates the Export_Web130_Factory state.</summary>
        bool ValidateExport_Web130_Factory();
    }

}