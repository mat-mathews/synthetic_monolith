using Admin.Api;
using Admin.Data117;
using Auth.Client;
using Common.Data;
using Common.Shared;
using Export.Handlers;
using GalaxyWorks.Contracts;
using Integration.Shared83;
using Notifications.Validators;
using Portal.Contracts170;
using Portal.Validators250;
using Portal.Web158;
using Reporting.Mappers;
using Reporting.Service207;
using Scheduling.Models342;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Client;

namespace Workflow.Processors
{
    internal interface IWorkflow_Processors_Factory2
    {
        /// <summary>Processes the Workflow_Processors_Factory2 operation.</summary>
        void ProcessWorkflow_Processors_Factory2();

        /// <summary>Validates the Workflow_Processors_Factory2 state.</summary>
        bool ValidateWorkflow_Processors_Factory2();
    }

}