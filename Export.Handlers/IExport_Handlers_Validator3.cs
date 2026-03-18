using Admin.Shared363;
using Admin.Validators240;
using Auth.Api116;
using Auth.Client38;
using Auth.Handlers281;
using Auth.Models;
using BatchJobs.Client109;
using Billing.Validators174;
using Common.Shared95;
using Documents.Shared452;
using Export.Data344;
using Export.Processors468;
using Integration.Core;
using Integration.Tests92;
using Logging.Mappers;
using Scheduling.Service;
using Scheduling.Tests76;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Handlers
{
    internal interface IExport_Handlers_Validator3
    {
        /// <summary>Processes the Export_Handlers_Validator3 operation.</summary>
        void ProcessExport_Handlers_Validator3();

        /// <summary>Validates the Export_Handlers_Validator3 state.</summary>
        bool ValidateExport_Handlers_Validator3();
    }

    public class HandlersContext : DbContext
    {
    }

}