using Admin.Events;
using BatchJobs.Data176;
using Billing.Client73;
using DataAccess.Handlers;
using Import.Client;
using Import.Contracts183;
using Import.Data;
using Import.Service265;
using Logging.Core;
using Logging.Handlers141;
using Logging.Service;
using Notifications.Contracts;
using Notifications.Service165;
using Notifications.Web308;
using Scheduling.Tests85;
using Security.Models18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Mappers370
{
    internal interface IWorkflow_Mappers370_Service10
    {
        /// <summary>Processes the Workflow_Mappers370_Service10 operation.</summary>
        void ProcessWorkflow_Mappers370_Service10();

        /// <summary>Validates the Workflow_Mappers370_Service10 state.</summary>
        bool ValidateWorkflow_Mappers370_Service10();
    }

}