using Admin.Handlers447;
using Admin.Handlers450;
using Admin.Models199;
using Auth.Client249;
using Auth.Core;
using Auth.Handlers209;
using Billing.Processors259;
using Common.Web488;
using Documents.Api;
using GalaxyWorks.Processors16;
using Integration.Tests;
using Logging.Models436;
using Portal.Mappers;
using Reporting.Client422;
using Scheduling.Core273;
using Scheduling.Models260;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators201;

namespace Workflow.Shared298
{
    internal interface IWorkflow_Shared298_Repository3
    {
        /// <summary>Processes the Workflow_Shared298_Repository3 operation.</summary>
        void ProcessWorkflow_Shared298_Repository3();

        /// <summary>Validates the Workflow_Shared298_Repository3 state.</summary>
        bool ValidateWorkflow_Shared298_Repository3();
    }

}