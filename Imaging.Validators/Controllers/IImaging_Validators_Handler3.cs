using Admin.Mappers;
using Admin.Mappers324;
using Admin.Web154;
using Auth.Core;
using Auth.Processors411;
using BatchJobs.Core;
using BatchJobs.Processors500;
using Billing.Processors388;
using DataAccess.Client82;
using Imaging.Processors;
using Imaging.Web172;
using Logging.Client405;
using Logging.Shared;
using Notifications.Data;
using Notifications.Web90;
using Portal.Processors52;
using Scheduling.Tests85;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;

namespace Imaging.Validators
{
    internal interface IImaging_Validators_Handler3
    {
        /// <summary>Processes the Imaging_Validators_Handler3 operation.</summary>
        void ProcessImaging_Validators_Handler3();

        /// <summary>Validates the Imaging_Validators_Handler3 state.</summary>
        bool ValidateImaging_Validators_Handler3();
    }

}