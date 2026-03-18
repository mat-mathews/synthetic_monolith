using Admin.Client177;
using Admin.Core121;
using Auth.Handlers;
using Billing.Core34;
using Common.Api213;
using DataAccess.Api454;
using Documents.Tests106;
using Import.Service15;
using Logging.Tests292;
using Notifications.Mappers110;
using Notifications.Mappers55;
using Reporting.Processors495;
using Security.Models136;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;
using Utilities.Handlers462;
using Utilities.Tests;
using Workflow.Data340;

namespace Reporting.Mappers
{
    /// <summary>Defines the possible states for Reporting_Mappers_Status8.</summary>
    internal enum Reporting_Mappers_Status8
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