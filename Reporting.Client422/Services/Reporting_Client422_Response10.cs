using Admin.Core;
using Admin.Handlers;
using Auth.Client249;
using BatchJobs.Events435;
using Export.Client13;
using Export.Web229;
using GalaxyWorks.Client;
using GalaxyWorks.Data;
using GalaxyWorks.Tests445;
using Import.Core;
using Import.Mappers56;
using Integration.Mappers;
using Logging.Tests;
using Notifications.Client;
using Security.Api320;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;

namespace Reporting.Client422
{
    /// <summary>Immutable data transfer record for Reporting_Client422_Response10.</summary>
    internal record Reporting_Client422_Response10(string Value, int Count, DateTime Timestamp);

}