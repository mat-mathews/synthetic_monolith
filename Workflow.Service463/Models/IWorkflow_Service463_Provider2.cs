using Auth.Api143;
using Auth.Mappers208;
using BatchJobs.Contracts;
using Billing.Mappers225;
using Common.Shared;
using GalaxyWorks.Core;
using GalaxyWorks.Processors16;
using GalaxyWorks.Service;
using Import.Api272;
using Logging.Events;
using Notifications.Shared;
using Notifications.Shared396;
using Portal.Contracts170;
using Portal.Service378;
using Portal.Validators69;
using Reporting.Client146;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Service463
{
    internal interface IWorkflow_Service463_Provider2
    {
        /// <summary>Processes the Workflow_Service463_Provider2 operation.</summary>
        void ProcessWorkflow_Service463_Provider2();

        /// <summary>Validates the Workflow_Service463_Provider2 state.</summary>
        bool ValidateWorkflow_Service463_Provider2();
    }

}