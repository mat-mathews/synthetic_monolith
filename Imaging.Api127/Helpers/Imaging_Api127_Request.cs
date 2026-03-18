using Admin.Data;
using Admin.Events306;
using Admin.Handlers447;
using Admin.Validators;
using Auth.Validators;
using BatchJobs.Handlers;
using Common.Shared95;
using Documents.Shared427;
using Export.Processors111;
using GalaxyWorks.Core309;
using Integration.Processors241;
using Integration.Tests;
using Notifications.Service475;
using Notifications.Web90;
using Portal.Web;
using Reporting.Shared394;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Imaging.Api127
{
    /// <summary>Immutable data transfer record for Imaging_Api127_Request.</summary>
    public record Imaging_Api127_Request(string Value, int Count, DateTime Timestamp);

    public class Api127Context : DbContext
    {
    }

}