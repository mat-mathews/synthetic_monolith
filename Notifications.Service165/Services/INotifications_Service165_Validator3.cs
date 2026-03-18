using Admin.Client346;
using Admin.Data117;
using Admin.Service364;
using Auth.Handlers467;
using Auth.Processors;
using Auth.Validators87;
using Billing.Contracts;
using Billing.Validators174;
using Common.Shared95;
using Export.Events;
using Export.Models262;
using Import.Contracts;
using Notifications.Processors;
using Reporting.Events483;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;
using Workflow.Processors;

namespace Notifications.Service165
{
    internal interface INotifications_Service165_Validator3
    {
        /// <summary>Processes the Notifications_Service165_Validator3 operation.</summary>
        void ProcessNotifications_Service165_Validator3();

        /// <summary>Validates the Notifications_Service165_Validator3 state.</summary>
        bool ValidateNotifications_Service165_Validator3();
    }

}