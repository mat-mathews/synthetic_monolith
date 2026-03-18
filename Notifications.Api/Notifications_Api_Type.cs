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
    /// <summary>Defines the possible states for Notifications_Api_Type.</summary>
    public enum Notifications_Api_Type
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}