using Admin.Events306;
using Admin.Handlers;
using Admin.Models199;
using BatchJobs.Api;
using Billing.Events;
using Common.Service258;
using GalaxyWorks.Web;
using Imaging.Models459;
using Import.Tests;
using Integration.Processors248;
using Notifications.Mappers110;
using Portal.Events151;
using Portal.Validators;
using Scheduling.Events;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Common.Shared95
{
    /// <summary>Defines the possible states for Common_Shared95_State6.</summary>
    public enum Common_Shared95_State6
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