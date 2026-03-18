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
    public interface INotifications_Service165_Repository2
    {
        /// <summary>Processes the Notifications_Service165_Repository2 operation.</summary>
        void ProcessNotifications_Service165_Repository2();

        /// <summary>Validates the Notifications_Service165_Repository2 state.</summary>
        bool ValidateNotifications_Service165_Repository2();
    }

}