using Admin.Service339;
using Auth.Client249;
using BatchJobs.Tests;
using DataAccess.Api;
using GalaxyWorks.Api390;
using GalaxyWorks.Client366;
using Imaging.Web172;
using Import.Client65;
using Integration.Events;
using Notifications.Shared380;
using Notifications.Tests;
using Reporting.Handlers347;
using Scheduling.Core273;
using Scheduling.Processors80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts192;
using Workflow.Web;

namespace Scheduling.Api185
{
    /// <summary>Immutable data transfer record for Scheduling_Api185_Request1.</summary>
    internal record Scheduling_Api185_Request1(string Value, int Count, DateTime Timestamp);

}