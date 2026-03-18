using Admin.Client346;
using Admin.Data;
using Admin.Handlers;
using Auth.Contracts395;
using BatchJobs.Api;
using Documents.Processors300;
using Export.Tests62;
using Export.Validators152;
using Logging.Handlers141;
using Notifications.Api144;
using Portal.Mappers233;
using Portal.Tests173;
using Reporting.Data;
using Scheduling.Tests444;
using Security.Events288;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;

namespace DataAccess.Api294
{
    /// <summary>Immutable data transfer record for DataAccess_Api294_ViewModel.</summary>
    internal record DataAccess_Api294_ViewModel(string Value, int Count, DateTime Timestamp);

}