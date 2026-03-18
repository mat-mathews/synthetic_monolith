using Admin.Handlers61;
using Admin.Mappers;
using Admin.Shared14;
using Auth.Client249;
using Auth.Contracts402;
using Auth.Handlers467;
using Auth.Shared325;
using Billing.Processors;
using Billing.Tests;
using Documents.Core;
using Documents.Processors133;
using GalaxyWorks.Tests;
using Import.Api314;
using Integration.Contracts290;
using Logging.Contracts74;
using Notifications.Processors;
using Reporting.Api393;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Core34
{
    /// <summary>Defines the possible states for Billing_Core34_Type12.</summary>
    public enum Billing_Core34_Type12
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