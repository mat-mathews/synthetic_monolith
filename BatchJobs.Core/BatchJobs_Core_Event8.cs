using Admin.Models199;
using Auth.Contracts;
using Auth.Mappers206;
using BatchJobs.Mappers;
using Billing.Service432;
using Export.Data150;
using Export.Data344;
using Export.Processors79;
using Imaging.Shared322;
using Imaging.Tests328;
using Logging.Models436;
using Notifications.Mappers110;
using Notifications.Processors;
using Reporting.Client;
using Scheduling.Api;
using Scheduling.Client;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;

namespace BatchJobs.Core
{
    /// <summary>Immutable data transfer record for BatchJobs_Core_Event8.</summary>
    public record BatchJobs_Core_Event8(string Value, int Count, DateTime Timestamp);

    public class CoreContext : DbContext
    {
    }

}