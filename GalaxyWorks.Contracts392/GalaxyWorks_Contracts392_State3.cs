using Admin.Mappers;
using Admin.Processors;
using Admin.Service247;
using BatchJobs.Handlers;
using Billing.Validators174;
using Common.Shared297;
using DataAccess.Tests;
using GalaxyWorks.Service;
using Integration.Shared83;
using Notifications.Core166;
using Notifications.Web90;
using Reporting.Mappers;
using Reporting.Shared394;
using Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Models;
using Utilities.Processors440;
using Utilities.Tests;

namespace GalaxyWorks.Contracts392
{
    /// <summary>Defines the possible states for GalaxyWorks_Contracts392_State3.</summary>
    public enum GalaxyWorks_Contracts392_State3
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