using Admin.Core121;
using Auth.Data;
using Auth.Events;
using Auth.Handlers;
using Billing.Core34;
using Billing.Processors259;
using DataAccess.Client82;
using Export.Handlers;
using GalaxyWorks.Data;
using Integration.Models;
using Logging.Handlers;
using Logging.Validators359;
using Notifications.Processors;
using Portal.Api99;
using Scheduling.Processors335;
using Scheduling.Shared;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators201;

namespace Reporting.Api287
{
    /// <summary>Defines the possible states for Reporting_Api287_Type6.</summary>
    internal enum Reporting_Api287_Type6
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