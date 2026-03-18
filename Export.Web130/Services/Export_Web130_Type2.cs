using Admin.Tests;
using Auth.Api143;
using Auth.Client249;
using BatchJobs.Tests;
using Billing.Api9;
using Billing.Data;
using Common.Models381;
using DataAccess.Models;
using Export.Models461;
using Export.Tests;
using Import.Client7;
using Integration.Client;
using Reporting.Events317;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Workflow.Client351;
using Workflow.Contracts192;
using Workflow.Web;

namespace Export.Web130
{
    /// <summary>Defines the possible states for Export_Web130_Type2.</summary>
    public enum Export_Web130_Type2
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}