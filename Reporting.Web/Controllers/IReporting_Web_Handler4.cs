using Admin.Contracts;
using Admin.Events235;
using Admin.Validators336;
using Auth.Client38;
using Common.Validators;
using DataAccess.Tests282;
using GalaxyWorks.Core;
using GalaxyWorks.Events77;
using GalaxyWorks.Tests;
using Import.Handlers167;
using Integration.Handlers244;
using Integration.Service477;
using Logging.Models379;
using Notifications.Data348;
using Notifications.Handlers470;
using Reporting.Validators;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;

namespace Reporting.Web
{
    public interface IReporting_Web_Handler4
    {
        /// <summary>Processes the Reporting_Web_Handler4 operation.</summary>
        void ProcessReporting_Web_Handler4();

        /// <summary>Validates the Reporting_Web_Handler4 state.</summary>
        bool ValidateReporting_Web_Handler4();
    }

}