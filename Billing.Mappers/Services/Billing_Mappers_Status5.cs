using Admin.Events306;
using Admin.Models199;
using Auth.Contracts395;
using Auth.Mappers178;
using BatchJobs.Tests270;
using DataAccess.Data36;
using Export.Events276;
using Integration.Handlers244;
using Notifications.Events42;
using Portal.Service231;
using Portal.Web158;
using Reporting.Contracts371;
using Reporting.Events188;
using Reporting.Tests;
using Security.Client353;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;

namespace Billing.Mappers
{
    /// <summary>Defines the possible states for Billing_Mappers_Status5.</summary>
    public enum Billing_Mappers_Status5
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