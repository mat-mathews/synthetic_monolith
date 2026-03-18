using Admin.Client346;
using Auth.Client271;
using Auth.Processors411;
using DataAccess.Processors;
using Documents.Shared;
using Export.Processors468;
using Import.Data193;
using Import.Service265;
using Logging.Contracts373;
using Logging.Handlers455;
using Notifications.Shared396;
using Portal.Validators69;
using Scheduling.Handlers63;
using Scheduling.Processors80;
using Security.Contracts238;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;

namespace Logging.Service382
{
    internal interface ILogging_Service382_Handler1
    {
        /// <summary>Processes the Logging_Service382_Handler1 operation.</summary>
        void ProcessLogging_Service382_Handler1();

        /// <summary>Validates the Logging_Service382_Handler1 state.</summary>
        bool ValidateLogging_Service382_Handler1();
    }

}