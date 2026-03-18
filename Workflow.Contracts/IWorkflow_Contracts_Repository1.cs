using Admin.Processors35;
using Auth.Events78;
using BatchJobs.Client;
using BatchJobs.Client267;
using BatchJobs.Processors;
using Common.Shared;
using Documents.Core;
using Documents.Handlers;
using Export.Core386;
using GalaxyWorks.Validators355;
using Imaging.Shared115;
using Import.Contracts131;
using Logging.Api316;
using Logging.Models379;
using Portal.Service231;
using Portal.Service378;
using Reporting.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Contracts
{
    public interface IWorkflow_Contracts_Repository1
    {
        /// <summary>Processes the Workflow_Contracts_Repository1 operation.</summary>
        void ProcessWorkflow_Contracts_Repository1();

        /// <summary>Validates the Workflow_Contracts_Repository1 state.</summary>
        bool ValidateWorkflow_Contracts_Repository1();
    }

}