using Admin.Service;
using Billing.Contracts;
using Common.Api186;
using Common.Service;
using DataAccess.Handlers;
using Documents.Core;
using Documents.Mappers;
using Export.Core372;
using Export.Processors449;
using GalaxyWorks.Data224;
using GalaxyWorks.Data375;
using Import.Events;
using Logging.Tests;
using Reporting.Events220;
using Security.Data278;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors440;

namespace Scheduling.Service211
{
    internal interface IScheduling_Service211_Provider
    {
        /// <summary>Processes the Scheduling_Service211_Provider operation.</summary>
        void ProcessScheduling_Service211_Provider();

        /// <summary>Validates the Scheduling_Service211_Provider state.</summary>
        bool ValidateScheduling_Service211_Provider();
    }

}