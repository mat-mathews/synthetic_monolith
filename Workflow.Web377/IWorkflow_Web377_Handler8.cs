using Auth.Client271;
using DataAccess.Mappers;
using Documents.Core;
using Documents.Events;
using Export.Processors104;
using GalaxyWorks.Data96;
using Import.Service496;
using Notifications.Tests;
using Portal.Handlers;
using Reporting.Events188;
using Reporting.Service207;
using Scheduling.Processors80;
using Scheduling.Tests76;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;
using Workflow.Tests;

namespace Workflow.Web377
{
    internal interface IWorkflow_Web377_Handler8
    {
        /// <summary>Processes the Workflow_Web377_Handler8 operation.</summary>
        void ProcessWorkflow_Web377_Handler8();

        /// <summary>Validates the Workflow_Web377_Handler8 state.</summary>
        bool ValidateWorkflow_Web377_Handler8();
    }

}