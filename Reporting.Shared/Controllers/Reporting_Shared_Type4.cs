using Admin.Core121;
using Auth.Data;
using Auth.Handlers;
using Auth.Handlers467;
using Export.Processors426;
using GalaxyWorks.Api;
using GalaxyWorks.Shared;
using Imaging.Data;
using Logging.Processors;
using Notifications.Core166;
using Portal.Events139;
using Portal.Validators250;
using Portal.Web158;
using Reporting.Mappers;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Workflow.Models253;

namespace Reporting.Shared
{
    /// <summary>Defines the possible states for Reporting_Shared_Type4.</summary>
    internal enum Reporting_Shared_Type4
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