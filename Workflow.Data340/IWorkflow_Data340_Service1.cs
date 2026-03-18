using Admin.Client177;
using Admin.Core121;
using Admin.Web46;
using BatchJobs.Tests;
using Common.Data81;
using DataAccess.Validators409;
using Export.Shared;
using GalaxyWorks.Data375;
using Integration.Events;
using Notifications.Handlers470;
using Notifications.Models466;
using Notifications.Service475;
using Portal.Core;
using Scheduling.Processors;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;

namespace Workflow.Data340
{
    public interface IWorkflow_Data340_Service1
    {
        /// <summary>Processes the Workflow_Data340_Service1 operation.</summary>
        void ProcessWorkflow_Data340_Service1();

        /// <summary>Validates the Workflow_Data340_Service1 state.</summary>
        bool ValidateWorkflow_Data340_Service1();
    }

}