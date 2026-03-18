using Auth.Api;
using Auth.Api143;
using DataAccess.Shared189;
using DataAccess.Validators409;
using Documents.Contracts;
using Export.Api;
using Export.Processors449;
using Integration.Api469;
using Integration.Processors241;
using Notifications.Core166;
using Portal.Core;
using Reporting.Processors326;
using Reporting.Processors495;
using Scheduling.Web221;
using Scheduling.Web264;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Validators
{
    /// <summary>Defines the possible states for Reporting_Validators_State4.</summary>
    public enum Reporting_Validators_State4
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