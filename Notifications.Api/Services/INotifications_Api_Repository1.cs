using Admin.Models476;
using Admin.Validators;
using Common.Core417;
using Export.Validators;
using GalaxyWorks.Api390;
using Import.Client64;
using Logging.Data29;
using Logging.Validators359;
using Notifications.Events;
using Reporting.Web345;
using Scheduling.Mappers442;
using Security.Events;
using Security.Processors295;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web398;
using Workflow.Events;

namespace Notifications.Api
{
    internal interface INotifications_Api_Repository1
    {
        /// <summary>Processes the Notifications_Api_Repository1 operation.</summary>
        void ProcessNotifications_Api_Repository1();

        /// <summary>Validates the Notifications_Api_Repository1 state.</summary>
        bool ValidateNotifications_Api_Repository1();
    }

}