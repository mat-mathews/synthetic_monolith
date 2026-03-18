using Admin.Events306;
using Admin.Mappers324;
using Admin.Validators240;
using Auth.Core2;
using Auth.Mappers206;
using Documents.Api156;
using Documents.Mappers;
using Documents.Shared427;
using Portal.Api123;
using Portal.Core8;
using Portal.Models;
using Reporting.Api287;
using Scheduling.Tests76;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts228;
using Workflow.Contracts;
using Workflow.Handlers;
using Workflow.Shared298;

namespace Billing.Events
{
    /// <summary>Defines the possible states for Billing_Events_State8.</summary>
    internal enum Billing_Events_State8
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