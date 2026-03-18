using Auth.Mappers;
using BatchJobs.Contracts399;
using Common.Events;
using DataAccess.Service464;
using Export.Processors111;
using GalaxyWorks.Data96;
using GalaxyWorks.Mappers403;
using GalaxyWorks.Web;
using Portal.Api352;
using Reporting.Tests67;
using Reporting.Web;
using Reporting.Web105;
using Scheduling.Core218;
using Scheduling.Tests214;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts192;
using Workflow.Mappers;

namespace DataAccess.Events
{
    /// <summary>Defines the possible states for DataAccess_Events_Category6.</summary>
    public enum DataAccess_Events_Category6
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