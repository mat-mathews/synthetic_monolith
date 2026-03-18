using Admin.Client346;
using Admin.Data117;
using Admin.Events235;
using Admin.Validators431;
using Admin.Web46;
using Auth.Core2;
using Common.Processors245;
using Documents.Shared334;
using Documents.Validators;
using Export.Service30;
using Imaging.Api127;
using Import.Service429;
using Notifications.Models466;
using Reporting.Mappers239;
using Scheduling.Shared39;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;
using Workflow.Validators138;

namespace Workflow.Shared
{
    public interface IWorkflow_Shared_Repository5
    {
        /// <summary>Processes the Workflow_Shared_Repository5 operation.</summary>
        void ProcessWorkflow_Shared_Repository5();

        /// <summary>Validates the Workflow_Shared_Repository5 state.</summary>
        bool ValidateWorkflow_Shared_Repository5();
    }

}