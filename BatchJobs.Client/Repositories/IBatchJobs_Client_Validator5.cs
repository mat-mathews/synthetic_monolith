using Admin.Api;
using Admin.Handlers;
using Auth.Data135;
using Billing.Events;
using Billing.Models;
using Common.Contracts279;
using Documents.Api156;
using Export.Api;
using GalaxyWorks.Data224;
using GalaxyWorks.Processors16;
using Imaging.Client261;
using Import.Contracts180;
using Notifications.Events42;
using Notifications.Service;
using Portal.Events151;
using Portal.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;
using Workflow.Web377;

namespace BatchJobs.Client
{
    internal interface IBatchJobs_Client_Validator5
    {
        /// <summary>Processes the BatchJobs_Client_Validator5 operation.</summary>
        void ProcessBatchJobs_Client_Validator5();

        /// <summary>Validates the BatchJobs_Client_Validator5 state.</summary>
        bool ValidateBatchJobs_Client_Validator5();
    }

}