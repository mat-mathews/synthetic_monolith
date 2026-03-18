using Admin.Processors;
using Admin.Shared310;
using Auth.Events78;
using Common.Client;
using DataAccess.Mappers;
using DataAccess.Validators409;
using Export.Models461;
using GalaxyWorks.Shared437;
using Import.Mappers;
using Import.Shared;
using Integration.Api;
using Logging.Service160;
using Portal.Client;
using Portal.Mappers233;
using Scheduling.Events;
using Scheduling.Tests76;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web40;

namespace Workflow.Validators201
{
    public interface IWorkflow_Validators201_Handler
    {
        /// <summary>Processes the Workflow_Validators201_Handler operation.</summary>
        void ProcessWorkflow_Validators201_Handler();

        /// <summary>Validates the Workflow_Validators201_Handler state.</summary>
        bool ValidateWorkflow_Validators201_Handler();
    }

}