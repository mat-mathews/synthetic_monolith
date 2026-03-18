using Admin.Client177;
using Admin.Contracts120;
using Admin.Data408;
using Auth.Data;
using Common.Validators50;
using DataAccess.Api;
using DataAccess.Api307;
using Export.Client13;
using Export.Processors468;
using Import.Handlers407;
using Logging.Api;
using Logging.Core159;
using Notifications.Data348;
using Portal.Validators;
using Reporting.Tests226;
using Scheduling.Tests444;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service358;

namespace BatchJobs.Service
{
    /// <summary>Immutable data transfer record for BatchJobs_Service_Request3.</summary>
    public record BatchJobs_Service_Request3(string Value, int Count, DateTime Timestamp);

}