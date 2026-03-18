using Admin.Contracts;
using Admin.Events235;
using Admin.Shared14;
using Admin.Web4;
using Auth.Client249;
using Auth.Core;
using Billing.Web;
using DataAccess.Client;
using Export.Processors;
using Import.Events493;
using Integration.Handlers17;
using Logging.Contracts373;
using Notifications.Data406;
using Notifications.Web;
using Reporting.Handlers;
using Scheduling.Data54;
using Scheduling.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Data446
{
    public interface INotifications_Data446_Service9
    {
        /// <summary>Processes the Notifications_Data446_Service9 operation.</summary>
        void ProcessNotifications_Data446_Service9();

        /// <summary>Validates the Notifications_Data446_Service9 state.</summary>
        bool ValidateNotifications_Data446_Service9();
    }

}