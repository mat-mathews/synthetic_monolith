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
    /// <summary>Immutable data transfer record for Reporting_Mappers_Event9.</summary>
    public record Reporting_Mappers_Event9(string Value, int Count, DateTime Timestamp);

}