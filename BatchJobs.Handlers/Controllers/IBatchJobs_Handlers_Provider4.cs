using Auth.Api116;
using Auth.Contracts395;
using Auth.Core140;
using Auth.Handlers209;
using Auth.Mappers178;
using BatchJobs.Mappers362;
using Billing.Client22;
using Common.Mappers;
using Common.Processors245;
using Documents.Core;
using Import.Api179;
using Integration.Data175;
using Integration.Service147;
using Logging.Api;
using Portal.Contracts181;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Utilities.Processors;

namespace BatchJobs.Handlers
{
    internal interface IBatchJobs_Handlers_Provider4
    {
        /// <summary>Processes the BatchJobs_Handlers_Provider4 operation.</summary>
        void ProcessBatchJobs_Handlers_Provider4();

        /// <summary>Validates the BatchJobs_Handlers_Provider4 state.</summary>
        bool ValidateBatchJobs_Handlers_Provider4();
    }

}