using Admin.Client177;
using Admin.Core121;
using Auth.Handlers209;
using Auth.Processors;
using BatchJobs.Api501;
using DataAccess.Service;
using Documents.Processors133;
using Export.Processors449;
using GalaxyWorks.Models;
using GalaxyWorks.Processors;
using Integration.Service;
using Integration.Service107;
using Portal.Service489;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;
using Workflow.Models;
using Workflow.Tests;

namespace Workflow.Handlers
{
    internal interface IWorkflow_Handlers_Provider5
    {
        /// <summary>Processes the Workflow_Handlers_Provider5 operation.</summary>
        void ProcessWorkflow_Handlers_Provider5();

        /// <summary>Validates the Workflow_Handlers_Provider5 state.</summary>
        bool ValidateWorkflow_Handlers_Provider5();
    }

}