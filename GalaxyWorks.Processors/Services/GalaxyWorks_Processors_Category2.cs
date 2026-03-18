using Admin.Data117;
using Auth.Api143;
using Auth.Contracts;
using Auth.Core;
using Auth.Mappers;
using Auth.Processors319;
using BatchJobs.Contracts;
using Documents.Service;
using Export.Service30;
using GalaxyWorks.Data96;
using Imaging.Client331;
using Integration.Handlers423;
using Integration.Mappers;
using Integration.Processors321;
using Notifications.Service165;
using Reporting.Handlers;
using Scheduling.Mappers48;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Processors
{
    /// <summary>Defines the possible states for GalaxyWorks_Processors_Category2.</summary>
    public enum GalaxyWorks_Processors_Category2
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