using Auth.Core;
using BatchJobs.Events435;
using Billing.Tests194;
using GalaxyWorks.Data224;
using Import.Data;
using Import.Service496;
using Logging.Core159;
using Notifications.Models277;
using Portal.Service489;
using Reporting.Web;
using Scheduling.Models441;
using Scheduling.Shared39;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors440;
using Workflow.Events327;
using Workflow.Processors;
using Workflow.Tests222;

namespace Notifications.Tests195
{
    /// <summary>Defines the possible states for Notifications_Tests195_Mode3.</summary>
    internal enum Notifications_Tests195_Mode3
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