using Admin.Shared310;
using Auth.Client249;
using BatchJobs.Events435;
using BatchJobs.Mappers362;
using Billing.Mappers225;
using DataAccess.Contracts404;
using Documents.Api156;
using Export.Processors;
using Integration.Data;
using Logging.Handlers141;
using Notifications.Handlers;
using Portal.Validators69;
using Scheduling.Models260;
using Security.Api320;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Workflow.Tests27;

namespace Logging.Contracts
{
    internal interface ILogging_Contracts_Handler6
    {
        /// <summary>Processes the Logging_Contracts_Handler6 operation.</summary>
        void ProcessLogging_Contracts_Handler6();

        /// <summary>Validates the Logging_Contracts_Handler6 state.</summary>
        bool ValidateLogging_Contracts_Handler6();
    }

}