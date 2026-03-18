using Admin.Events235;
using Admin.Models476;
using Auth.Core140;
using Auth.Mappers178;
using BatchJobs.Contracts399;
using Billing.Shared384;
using Common.Contracts;
using Common.Core417;
using DataAccess.Data36;
using GalaxyWorks.Models219;
using Portal.Service489;
using Portal.Validators125;
using Reporting.Api393;
using Scheduling.Processors25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers97;
using Utilities.Models41;
using Workflow.Contracts192;

namespace BatchJobs.Processors500
{
    public interface IBatchJobs_Processors500_Provider5
    {
        /// <summary>Processes the BatchJobs_Processors500_Provider5 operation.</summary>
        void ProcessBatchJobs_Processors500_Provider5();

        /// <summary>Validates the BatchJobs_Processors500_Provider5 state.</summary>
        bool ValidateBatchJobs_Processors500_Provider5();
    }

}