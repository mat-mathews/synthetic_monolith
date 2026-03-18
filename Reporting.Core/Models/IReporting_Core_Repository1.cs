using Admin.Contracts;
using Admin.Core121;
using Admin.Handlers450;
using Auth.Handlers;
using Billing.Service;
using DataAccess.Api454;
using DataAccess.Web200;
using Export.Models262;
using Import.Core;
using Import.Service265;
using Logging.Api316;
using Notifications.Data348;
using Notifications.Service;
using Notifications.Tests;
using Reporting.Client;
using Reporting.Tests226;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web;

namespace Reporting.Core
{
    internal interface IReporting_Core_Repository1
    {
        /// <summary>Processes the Reporting_Core_Repository1 operation.</summary>
        void ProcessReporting_Core_Repository1();

        /// <summary>Validates the Reporting_Core_Repository1 state.</summary>
        bool ValidateReporting_Core_Repository1();
    }

}