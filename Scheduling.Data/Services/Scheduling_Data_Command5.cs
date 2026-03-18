using Admin.Client177;
using Admin.Service364;
using Admin.Tests;
using Billing.Contracts;
using Billing.Core191;
using Billing.Tests194;
using DataAccess.Api454;
using Documents.Contracts;
using Export.Events;
using Import.Contracts183;
using Notifications.Tests195;
using Reporting.Contracts;
using Scheduling.Mappers48;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Utilities.Shared;
using Workflow.Tests27;

namespace Scheduling.Data
{
    /// <summary>Immutable data transfer record for Scheduling_Data_Command5.</summary>
    public record Scheduling_Data_Command5(string Value, int Count, DateTime Timestamp);

}