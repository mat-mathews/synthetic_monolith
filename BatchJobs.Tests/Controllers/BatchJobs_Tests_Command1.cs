using Admin.Events306;
using Auth.Contracts395;
using BatchJobs.Api501;
using BatchJobs.Validators;
using Billing.Models;
using Import.Data193;
using Integration.Service401;
using Integration.Tests86;
using Reporting.Processors326;
using Scheduling.Web196;
using Security.Contracts499;
using Security.Models;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;
using Workflow.Contracts434;
using Workflow.Tests222;

namespace BatchJobs.Tests
{
    /// <summary>Immutable data transfer record for BatchJobs_Tests_Command1.</summary>
    internal record BatchJobs_Tests_Command1(string Value, int Count, DateTime Timestamp);

}