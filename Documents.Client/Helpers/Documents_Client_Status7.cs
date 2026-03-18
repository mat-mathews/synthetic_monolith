using Admin.Contracts;
using Auth.Events5;
using Auth.Handlers467;
using Auth.Web70;
using BatchJobs.Events435;
using Billing.Shared312;
using Documents.Contracts;
using Export.Tests62;
using Import.Data193;
using Reporting.Events188;
using Scheduling.Api185;
using Scheduling.Contracts425;
using Scheduling.Models342;
using Scheduling.Web19;
using Security.Models18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Mappers;
using Utilities.Web398;

namespace Documents.Client
{
    /// <summary>Defines the possible states for Documents_Client_Status7.</summary>
    public enum Documents_Client_Status7
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