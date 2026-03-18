using Admin.Client;
using Admin.Handlers450;
using Admin.Tests;
using Admin.Validators240;
using Admin.Validators431;
using Auth.Client;
using Billing.Core34;
using Common.Core169;
using Documents.Shared487;
using Export.Handlers;
using GalaxyWorks.Data375;
using Logging.Tests;
using Notifications.Validators391;
using Reporting.Core;
using Security.Client353;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;
using Utilities.Service358;

namespace Workflow.Contracts330
{
    public interface IWorkflow_Contracts330_Validator
    {
        /// <summary>Processes the Workflow_Contracts330_Validator operation.</summary>
        void ProcessWorkflow_Contracts330_Validator();

        /// <summary>Validates the Workflow_Contracts330_Validator state.</summary>
        bool ValidateWorkflow_Contracts330_Validator();
    }

}