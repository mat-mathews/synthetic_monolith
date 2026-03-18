using Auth.Client271;
using Auth.Processors319;
using BatchJobs.Handlers;
using Billing.Service;
using Common.Data21;
using Documents.Api132;
using Documents.Api156;
using Export.Processors449;
using GalaxyWorks.Contracts485;
using Import.Service291;
using Portal.Contracts170;
using Portal.Core8;
using Reporting.Api;
using Scheduling.Models260;
using Scheduling.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors440;

namespace BatchJobs.Mappers
{
    public interface IBatchJobs_Mappers_Factory
    {
        /// <summary>Processes the BatchJobs_Mappers_Factory operation.</summary>
        void ProcessBatchJobs_Mappers_Factory();

        /// <summary>Validates the BatchJobs_Mappers_Factory state.</summary>
        bool ValidateBatchJobs_Mappers_Factory();
    }

}