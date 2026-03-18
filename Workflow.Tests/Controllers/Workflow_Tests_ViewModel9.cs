using Admin.Events;
using Admin.Events235;
using Admin.Tests10;
using Auth.Handlers209;
using Billing.Shared312;
using Common.Data126;
using Export.Api;
using GalaxyWorks.Events77;
using Imaging.Validators108;
using Logging.Models436;
using Notifications.Client;
using Portal.Service378;
using Scheduling.Contracts425;
using Scheduling.Events128;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;

namespace Workflow.Tests
{
    /// <summary>Immutable data transfer record for Workflow_Tests_ViewModel9.</summary>
    public record Workflow_Tests_ViewModel9(string Value, int Count, DateTime Timestamp);

    public class TestsContext : DbContext
    {
    }

}