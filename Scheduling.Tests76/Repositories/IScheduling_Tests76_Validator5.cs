using Admin.Handlers;
using Auth.Client271;
using Auth.Mappers28;
using BatchJobs.Mappers362;
using Billing.Tests194;
using Billing.Validators305;
using DataAccess.Client;
using Documents.Events;
using Export.Events276;
using Export.Processors;
using GalaxyWorks.Handlers;
using Imaging.Validators;
using Logging.Service;
using Portal.Core;
using Reporting.Core;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts;
using Workflow.Events327;

namespace Scheduling.Tests76
{
    internal interface IScheduling_Tests76_Validator5
    {
        /// <summary>Processes the Scheduling_Tests76_Validator5 operation.</summary>
        void ProcessScheduling_Tests76_Validator5();

        /// <summary>Validates the Scheduling_Tests76_Validator5 state.</summary>
        bool ValidateScheduling_Tests76_Validator5();
    }

}