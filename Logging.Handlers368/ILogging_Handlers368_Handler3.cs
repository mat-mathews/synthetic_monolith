using Admin.Client346;
using Admin.Validators37;
using Auth.Core140;
using BatchJobs.Service;
using Billing.Core34;
using DataAccess.Models;
using Export.Core;
using Export.Core168;
using Imaging.Web;
using Import.Client65;
using Import.Mappers56;
using Integration.Api469;
using Logging.Client405;
using Notifications.Processors;
using Security.Mappers313;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts;

namespace Logging.Handlers368
{
    public interface ILogging_Handlers368_Handler3
    {
        /// <summary>Processes the Logging_Handlers368_Handler3 operation.</summary>
        void ProcessLogging_Handlers368_Handler3();

        /// <summary>Validates the Logging_Handlers368_Handler3 state.</summary>
        bool ValidateLogging_Handlers368_Handler3();
    }

}