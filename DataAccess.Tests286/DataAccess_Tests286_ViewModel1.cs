using Admin.Core121;
using Admin.Service;
using Auth.Contracts402;
using Auth.Processors;
using BatchJobs.Data176;
using Billing.Web;
using Common.Events;
using Export.Client13;
using Export.Tests62;
using GalaxyWorks.Data263;
using Imaging.Mappers93;
using Logging.Events;
using Notifications.Core166;
using Notifications.Data;
using Portal.Contracts;
using Portal.Web158;
using Reporting.Shared394;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Tests286
{
    /// <summary>Immutable data transfer record for DataAccess_Tests286_ViewModel1.</summary>
    public record DataAccess_Tests286_ViewModel1(string Value, int Count, DateTime Timestamp);

}