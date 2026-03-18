using Admin.Data117;
using Admin.Handlers450;
using Admin.Service364;
using Auth.Models23;
using Auth.Processors;
using Billing.Api;
using Billing.Mappers;
using Billing.Tests194;
using Common.Api213;
using Export.Data344;
using GalaxyWorks.Contracts;
using Imaging.Events;
using Import.Events493;
using Portal.Tests173;
using Reporting.Data;
using Scheduling.Tests76;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers197;
using Workflow.Tests222;

namespace Export.Shared145
{
    /// <summary>Defines the possible states for Export_Shared145_State7.</summary>
    public enum Export_Shared145_State7
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