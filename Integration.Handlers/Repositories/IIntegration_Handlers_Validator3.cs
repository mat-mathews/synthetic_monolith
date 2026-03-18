using Admin.Client177;
using Admin.Events;
using Auth.Events78;
using Billing.Client22;
using DataAccess.Client;
using Documents.Shared427;
using Imaging.Client;
using Imaging.Shared115;
using Integration.Service477;
using Integration.Tests;
using Logging.Events;
using Logging.Validators;
using Notifications.Shared380;
using Scheduling.Models441;
using Scheduling.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Core;
using Workflow.Data340;

namespace Integration.Handlers
{
    internal interface IIntegration_Handlers_Validator3
    {
        /// <summary>Processes the Integration_Handlers_Validator3 operation.</summary>
        void ProcessIntegration_Handlers_Validator3();

        /// <summary>Validates the Integration_Handlers_Validator3 state.</summary>
        bool ValidateIntegration_Handlers_Validator3();
    }

}