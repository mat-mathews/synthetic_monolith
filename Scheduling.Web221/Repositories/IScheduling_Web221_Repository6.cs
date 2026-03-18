using Admin.Handlers;
using Billing.Client182;
using Billing.Processors388;
using Common.Processors142;
using Common.Web438;
using Export.Client;
using Export.Data;
using Export.Models262;
using GalaxyWorks.Client;
using Import.Api314;
using Import.Client;
using Integration.Data;
using Reporting.Contracts;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared;
using Workflow.Tests75;

namespace Scheduling.Web221
{
    internal interface IScheduling_Web221_Repository6
    {
        /// <summary>Processes the Scheduling_Web221_Repository6 operation.</summary>
        void ProcessScheduling_Web221_Repository6();

        /// <summary>Validates the Scheduling_Web221_Repository6 state.</summary>
        bool ValidateScheduling_Web221_Repository6();
    }

}