using Admin.Client346;
using Auth.Contracts395;
using Billing.Processors103;
using DataAccess.Validators88;
using Documents.Tests;
using Export.Processors361;
using GalaxyWorks.Tests445;
using Integration.Client;
using Integration.Handlers17;
using Integration.Mappers;
using Notifications.Tests299;
using Portal.Validators69;
using Reporting.Web105;
using Scheduling.Core273;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web377;

namespace Scheduling.Api3
{
    /// <summary>Immutable data transfer record for Scheduling_Api3_Response.</summary>
    public record Scheduling_Api3_Response(string Value, int Count, DateTime Timestamp);

}