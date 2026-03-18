using Admin.Data;
using Admin.Events235;
using Admin.Models;
using Admin.Service456;
using Admin.Shared14;
using Auth.Contracts;
using BatchJobs.Validators;
using Documents.Data;
using Export.Data150;
using Imaging.Client261;
using Import.Processors412;
using Integration.Service147;
using Logging.Core159;
using Scheduling.Contracts425;
using Security.Contracts238;
using Security.Processors295;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Workflow.Client
{
    public interface IWorkflow_Client_Validator7
    {
        /// <summary>Processes the Workflow_Client_Validator7 operation.</summary>
        void ProcessWorkflow_Client_Validator7();

        /// <summary>Validates the Workflow_Client_Validator7 state.</summary>
        bool ValidateWorkflow_Client_Validator7();
    }

}