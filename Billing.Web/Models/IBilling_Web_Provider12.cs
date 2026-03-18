using Admin.Data;
using Admin.Events235;
using Auth.Handlers;
using Auth.Shared;
using DataAccess.Contracts404;
using DataAccess.Validators;
using Import.Api314;
using Import.Processors412;
using Import.Processors472;
using Logging.Contracts;
using Notifications.Validators252;
using Portal.Data266;
using Reporting.Events220;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers97;
using Workflow.Core;
using Workflow.Tests27;

namespace Billing.Web
{
    public interface IBilling_Web_Provider12
    {
        /// <summary>Processes the Billing_Web_Provider12 operation.</summary>
        void ProcessBilling_Web_Provider12();

        /// <summary>Validates the Billing_Web_Provider12 state.</summary>
        bool ValidateBilling_Web_Provider12();
    }

}