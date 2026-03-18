using Admin.Processors;
using Admin.Validators240;
using BatchJobs.Api212;
using BatchJobs.Models304;
using Billing.Processors388;
using Common.Handlers;
using DataAccess.Models;
using Documents.Api132;
using Export.Processors104;
using GalaxyWorks.Data153;
using Imaging.Service;
using Import.Models;
using Integration.Core;
using Scheduling.Client;
using Scheduling.Handlers43;
using Scheduling.Tests444;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Handlers354
{
    /// <summary>Defines the possible states for Import_Handlers354_Category3.</summary>
    public enum Import_Handlers354_Category3
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