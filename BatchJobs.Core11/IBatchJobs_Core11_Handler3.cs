using Admin.Contracts120;
using Admin.Service247;
using Auth.Contracts;
using Billing.Data;
using Billing.Tests;
using Export.Mappers;
using Imaging.Core;
using Import.Handlers167;
using Integration.Data175;
using Integration.Mappers;
using Notifications.Events42;
using Scheduling.Mappers48;
using Scheduling.Processors25;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Utilities.Validators;
using Workflow.Client351;

namespace BatchJobs.Core11
{
    internal interface IBatchJobs_Core11_Handler3
    {
        /// <summary>Processes the BatchJobs_Core11_Handler3 operation.</summary>
        void ProcessBatchJobs_Core11_Handler3();

        /// <summary>Validates the BatchJobs_Core11_Handler3 state.</summary>
        bool ValidateBatchJobs_Core11_Handler3();
    }

}