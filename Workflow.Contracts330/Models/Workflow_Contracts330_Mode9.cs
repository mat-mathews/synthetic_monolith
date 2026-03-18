using Admin.Client;
using Admin.Handlers450;
using Admin.Tests;
using Admin.Validators240;
using Admin.Validators431;
using Auth.Client;
using Billing.Core34;
using Common.Core169;
using Documents.Shared487;
using Export.Handlers;
using GalaxyWorks.Data375;
using Logging.Tests;
using Notifications.Validators391;
using Reporting.Core;
using Security.Client353;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;
using Utilities.Service358;

namespace Workflow.Contracts330
{
    /// <summary>Defines the possible states for Workflow_Contracts330_Mode9.</summary>
    internal enum Workflow_Contracts330_Mode9
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