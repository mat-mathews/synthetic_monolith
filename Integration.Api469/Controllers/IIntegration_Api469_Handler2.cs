using Admin.Core121;
using Auth.Contracts395;
using Auth.Core140;
using BatchJobs.Client;
using BatchJobs.Validators311;
using Billing.Api497;
using Billing.Processors259;
using Documents.Data419;
using GalaxyWorks.Api390;
using Imaging.Contracts;
using Import.Core;
using Portal.Validators125;
using Scheduling.Api3;
using Security.Models420;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;
using Workflow.Contracts;

namespace Integration.Api469
{
    internal interface IIntegration_Api469_Handler2
    {
        /// <summary>Processes the Integration_Api469_Handler2 operation.</summary>
        void ProcessIntegration_Api469_Handler2();

        /// <summary>Validates the Integration_Api469_Handler2 state.</summary>
        bool ValidateIntegration_Api469_Handler2();
    }

}