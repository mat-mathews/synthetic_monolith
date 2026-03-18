using Admin.Client;
using Admin.Models;
using Billing.Tests;
using Common.Data126;
using GalaxyWorks.Tests;
using Imaging.Data;
using Imaging.Mappers93;
using Imaging.Shared322;
using Imaging.Web172;
using Import.Client65;
using Notifications.Tests;
using Reporting.Tests226;
using Security.Shared;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Processors440;
using Workflow.Service;

namespace GalaxyWorks.Core309
{
    /// <summary>Defines the possible states for GalaxyWorks_Core309_Type10.</summary>
    internal enum GalaxyWorks_Core309_Type10
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