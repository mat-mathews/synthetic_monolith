using Admin.Mappers;
using Auth.Core140;
using Auth.Handlers281;
using Auth.Mappers28;
using BatchJobs.Data;
using BatchJobs.Service;
using Common.Client;
using DataAccess.Api294;
using DataAccess.Processors;
using Import.Events;
using Import.Processors472;
using Import.Validators;
using Notifications.Events;
using Portal.Contracts170;
using Scheduling.Tests;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;

namespace Export.Web479
{
    internal interface IExport_Web479_Service11
    {
        /// <summary>Processes the Export_Web479_Service11 operation.</summary>
        void ProcessExport_Web479_Service11();

        /// <summary>Validates the Export_Web479_Service11 state.</summary>
        bool ValidateExport_Web479_Service11();
    }

}