using Admin.Handlers447;
using Admin.Mappers;
using Admin.Models476;
using Common.Client53;
using Common.Events;
using Export.Processors361;
using Export.Processors79;
using GalaxyWorks.Handlers478;
using Import.Client64;
using Integration.Shared;
using Logging.Shared315;
using Notifications.Api144;
using Notifications.Shared;
using Reporting.Core;
using Scheduling.Models;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Workflow.Client47;

namespace Reporting.Api
{
    /// <summary>Immutable data transfer record for Reporting_Api_Request1.</summary>
    internal record Reporting_Api_Request1(string Value, int Count, DateTime Timestamp);

}