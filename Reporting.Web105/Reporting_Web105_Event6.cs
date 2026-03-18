using Admin.Service364;
using Admin.Web154;
using Auth.Contracts402;
using BatchJobs.Handlers;
using BatchJobs.Handlers443;
using Common.Data126;
using DataAccess.Models;
using Export.Web210;
using GalaxyWorks.Client;
using GalaxyWorks.Core309;
using GalaxyWorks.Handlers;
using Scheduling.Handlers;
using Scheduling.Web;
using Security.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;
using Workflow.Service463;
using Workflow.Shared298;

namespace Reporting.Web105
{
    /// <summary>Immutable data transfer record for Reporting_Web105_Event6.</summary>
    public record Reporting_Web105_Event6(string Value, int Count, DateTime Timestamp);

}