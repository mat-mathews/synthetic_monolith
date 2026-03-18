using Admin.Core;
using Auth.Client38;
using Billing.Models;
using Common.Core417;
using Export.Core;
using Export.Processors104;
using GalaxyWorks.Contracts392;
using Import.Handlers407;
using Integration.Events;
using Integration.Mappers242;
using Logging.Processors;
using Notifications.Client257;
using Notifications.Validators391;
using Portal.Web494;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;
using Workflow.Validators;

namespace BatchJobs.Client109
{
    internal interface IBatchJobs_Client109_Factory2
    {
        /// <summary>Processes the BatchJobs_Client109_Factory2 operation.</summary>
        void ProcessBatchJobs_Client109_Factory2();

        /// <summary>Validates the BatchJobs_Client109_Factory2 state.</summary>
        bool ValidateBatchJobs_Client109_Factory2();
    }

}