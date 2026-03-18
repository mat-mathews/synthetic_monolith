using Admin.Events;
using Admin.Shared310;
using Admin.Web154;
using BatchJobs.Processors410;
using Billing.Tests194;
using DataAccess.Contracts404;
using Documents.Tests171;
using Documents.Tests458;
using Export.Models461;
using Export.Web130;
using GalaxyWorks.Data453;
using Imaging.Client;
using Imaging.Tests328;
using Notifications.Models466;
using Portal.Data;
using Reporting.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Events220
{
    /// <summary>Defines the possible states for Reporting_Events220_State.</summary>
    internal enum Reporting_Events220_State
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