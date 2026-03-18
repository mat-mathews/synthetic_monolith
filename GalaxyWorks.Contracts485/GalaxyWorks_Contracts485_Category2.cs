using Admin.Mappers;
using Admin.Web154;
using Auth.Handlers281;
using BatchJobs.Core;
using GalaxyWorks.Contracts;
using Imaging.Shared322;
using Import.Contracts296;
using Import.Processors412;
using Logging.Contracts74;
using Logging.Events;
using Logging.Models436;
using Scheduling.Shared;
using Security.Tests;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service358;
using Workflow.Processors;

namespace GalaxyWorks.Contracts485
{
    /// <summary>Defines the possible states for GalaxyWorks_Contracts485_Category2.</summary>
    public enum GalaxyWorks_Contracts485_Category2
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