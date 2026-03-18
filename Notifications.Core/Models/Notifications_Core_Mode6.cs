using Admin.Handlers61;
using Auth.Models23;
using BatchJobs.Api;
using BatchJobs.Shared;
using Documents.Api;
using Documents.Api156;
using Export.Processors361;
using GalaxyWorks.Contracts392;
using Notifications.Tests195;
using Reporting.Handlers347;
using Scheduling.Models260;
using Security.Api;
using Security.Contracts72;
using Security.Models;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests222;

namespace Notifications.Core
{
    /// <summary>Defines the possible states for Notifications_Core_Mode6.</summary>
    public enum Notifications_Core_Mode6
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