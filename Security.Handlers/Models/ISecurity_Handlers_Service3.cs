using Admin.Api;
using Admin.Client346;
using Auth.Data135;
using BatchJobs.Events435;
using Billing.Handlers122;
using Billing.Processors;
using Documents.Validators102;
using Import.Data;
using Import.Events;
using Logging.Handlers141;
using Notifications.Tests195;
using Notifications.Web;
using Reporting.Events317;
using Scheduling.Mappers442;
using Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;

namespace Security.Handlers
{
    internal interface ISecurity_Handlers_Service3
    {
        /// <summary>Processes the Security_Handlers_Service3 operation.</summary>
        void ProcessSecurity_Handlers_Service3();

        /// <summary>Validates the Security_Handlers_Service3 state.</summary>
        bool ValidateSecurity_Handlers_Service3();
    }

}