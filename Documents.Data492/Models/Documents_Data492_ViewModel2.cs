using Admin.Handlers450;
using Admin.Service364;
using Auth.Core140;
using BatchJobs.Mappers31;
using Billing.Client;
using Billing.Processors103;
using Common.Core118;
using DataAccess.Tests;
using GalaxyWorks.Tests445;
using Logging.Service160;
using Notifications.Service475;
using Notifications.Shared396;
using Scheduling.Processors337;
using Security.Events288;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;

namespace Documents.Data492
{
    /// <summary>Immutable data transfer record for Documents_Data492_ViewModel2.</summary>
    internal record Documents_Data492_ViewModel2(string Value, int Count, DateTime Timestamp);

}