using Admin.Service;
using Auth.Client38;
using Auth.Contracts;
using Auth.Data135;
using Auth.Mappers178;
using Billing.Contracts;
using Common.Api57;
using Common.Mappers;
using GalaxyWorks.Handlers;
using GalaxyWorks.Mappers;
using Import.Mappers56;
using Logging.Api;
using Portal.Data;
using Portal.Tests323;
using Scheduling.Processors80;
using Scheduling.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Security.Web230
{
    /// <summary>Defines the possible states for Security_Web230_Status.</summary>
    public enum Security_Web230_Status
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