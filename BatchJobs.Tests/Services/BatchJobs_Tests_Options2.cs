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
    public struct BatchJobs_Tests_Options2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}