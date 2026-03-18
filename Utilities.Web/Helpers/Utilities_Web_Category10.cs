using Auth.Mappers206;
using BatchJobs.Validators;
using Billing.Api9;
using Billing.Models;
using Common.Core;
using Export.Handlers;
using Export.Web210;
using Integration.Processors248;
using Integration.Validators;
using Logging.Client405;
using Logging.Events289;
using Logging.Tests292;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Client;
using Workflow.Client;
using Workflow.Data340;
using Workflow.Mappers;

namespace Utilities.Web
{
    /// <summary>Defines the possible states for Utilities_Web_Category10.</summary>
    public enum Utilities_Web_Category10
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