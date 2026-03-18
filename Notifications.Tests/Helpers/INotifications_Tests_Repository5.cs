using Admin.Client346;
using Admin.Handlers;
using Admin.Shared363;
using Auth.Mappers208;
using Auth.Web70;
using Billing.Events;
using Documents.Data419;
using Imaging.Contracts;
using Imaging.Data;
using Import.Contracts;
using Logging.Client405;
using Notifications.Shared396;
using Portal.Api51;
using Scheduling.Data;
using Scheduling.Service211;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web377;

namespace Notifications.Tests
{
    internal interface INotifications_Tests_Repository5
    {
        /// <summary>Processes the Notifications_Tests_Repository5 operation.</summary>
        void ProcessNotifications_Tests_Repository5();

        /// <summary>Validates the Notifications_Tests_Repository5 state.</summary>
        bool ValidateNotifications_Tests_Repository5();
    }

}