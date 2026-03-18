using Admin.Processors35;
using Auth.Client;
using BatchJobs.Contracts;
using BatchJobs.Validators;
using BatchJobs.Validators311;
using Billing.Service302;
using Billing.Tests;
using Billing.Tests194;
using DataAccess.Contracts203;
using Import.Client356;
using Logging.Tests;
using Reporting.Core;
using Reporting.Service207;
using Scheduling.Handlers;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;

namespace BatchJobs.Shared
{
    /// <summary>Immutable data transfer record for BatchJobs_Shared_Response1.</summary>
    internal record BatchJobs_Shared_Response1(string Value, int Count, DateTime Timestamp);

}