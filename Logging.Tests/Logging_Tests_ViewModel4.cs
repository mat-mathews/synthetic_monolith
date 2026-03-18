using Admin.Data408;
using Admin.Shared310;
using Auth.Data135;
using Auth.Handlers209;
using BatchJobs.Processors410;
using Billing.Shared149;
using Common.Core;
using Imaging.Events303;
using Integration.Models;
using Logging.Client405;
using Notifications.Handlers;
using Portal.Service378;
using Portal.Tests481;
using Reporting.Service207;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client;

namespace Logging.Tests
{
    /// <summary>Immutable data transfer record for Logging_Tests_ViewModel4.</summary>
    public record Logging_Tests_ViewModel4(string Value, int Count, DateTime Timestamp);

}