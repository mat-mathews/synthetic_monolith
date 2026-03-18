using Admin.Api255;
using Admin.Handlers;
using Admin.Handlers61;
using Admin.Shared363;
using Auth.Data;
using Billing.Api9;
using Billing.Handlers101;
using Common.Events367;
using Common.Web;
using Documents.Client;
using Import.Processors;
using Integration.Processors71;
using Notifications.Shared;
using Portal.Events139;
using Scheduling.Core;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;

namespace Notifications.Handlers112
{
    internal interface INotifications_Handlers112_Service2
    {
        /// <summary>Processes the Notifications_Handlers112_Service2 operation.</summary>
        void ProcessNotifications_Handlers112_Service2();

        /// <summary>Validates the Notifications_Handlers112_Service2 state.</summary>
        bool ValidateNotifications_Handlers112_Service2();
    }

}