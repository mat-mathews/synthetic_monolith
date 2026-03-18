using Admin.Contracts120;
using Admin.Events306;
using Admin.Shared;
using Auth.Events;
using Auth.Handlers209;
using Auth.Handlers467;
using BatchJobs.Processors410;
using Imaging.Validators108;
using Import.Client356;
using Logging.Contracts373;
using Logging.Events289;
using Logging.Service382;
using Notifications.Handlers112;
using Notifications.Validators252;
using Reporting.Client422;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Workflow.Models;

namespace Common.Contracts
{
    public interface ICommon_Contracts_Handler6
    {
        /// <summary>Processes the Common_Contracts_Handler6 operation.</summary>
        void ProcessCommon_Contracts_Handler6();

        /// <summary>Validates the Common_Contracts_Handler6 state.</summary>
        bool ValidateCommon_Contracts_Handler6();
    }

}