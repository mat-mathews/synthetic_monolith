using Admin.Handlers447;
using Admin.Validators37;
using Auth.Events;
using Auth.Handlers467;
using Auth.Tests;
using DataAccess.Api454;
using Documents.Api132;
using Export.Client13;
using Export.Processors426;
using Imaging.Tests328;
using Import.Api179;
using Portal.Shared;
using Portal.Tests;
using Scheduling.Processors335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts192;
using Workflow.Shared298;

namespace BatchJobs.Processors410
{
    public interface IBatchJobs_Processors410_Repository3
    {
        /// <summary>Processes the BatchJobs_Processors410_Repository3 operation.</summary>
        void ProcessBatchJobs_Processors410_Repository3();

        /// <summary>Validates the BatchJobs_Processors410_Repository3 state.</summary>
        bool ValidateBatchJobs_Processors410_Repository3();
    }

}