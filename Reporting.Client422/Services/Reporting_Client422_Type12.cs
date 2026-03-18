using Admin.Core;
using Admin.Handlers;
using Auth.Client249;
using BatchJobs.Events435;
using Export.Client13;
using Export.Web229;
using GalaxyWorks.Client;
using GalaxyWorks.Data;
using GalaxyWorks.Tests445;
using Import.Core;
using Import.Mappers56;
using Integration.Mappers;
using Logging.Tests;
using Notifications.Client;
using Security.Api320;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;

namespace Reporting.Client422
{
    /// <summary>Defines the possible states for Reporting_Client422_Type12.</summary>
    public enum Reporting_Client422_Type12
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