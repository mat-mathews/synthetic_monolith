using Admin.Handlers447;
using Admin.Service;
using Admin.Shared310;
using Billing.Api;
using Billing.Events;
using Billing.Tests;
using DataAccess.Client;
using Export.Processors104;
using GalaxyWorks.Api;
using Integration.Validators369;
using Logging.Service;
using Notifications.Events;
using Portal.Api;
using Portal.Tests173;
using Reporting.Contracts;
using Scheduling.Handlers63;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Shared
{
    public interface INotifications_Shared_Validator5
    {
        /// <summary>Processes the Notifications_Shared_Validator5 operation.</summary>
        void ProcessNotifications_Shared_Validator5();

        /// <summary>Validates the Notifications_Shared_Validator5 state.</summary>
        bool ValidateNotifications_Shared_Validator5();
    }

}