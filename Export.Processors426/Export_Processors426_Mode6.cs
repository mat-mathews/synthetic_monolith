using Admin.Validators431;
using Auth.Client249;
using Auth.Handlers281;
using Auth.Models236;
using Documents.Api129;
using GalaxyWorks.Mappers403;
using Import.Handlers354;
using Integration.Processors248;
using Integration.Service;
using Notifications.Data406;
using Portal.Core8;
using Reporting.Tests67;
using Security.Client349;
using Security.Models136;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web40;

namespace Export.Processors426
{
    /// <summary>Defines the possible states for Export_Processors426_Mode6.</summary>
    internal enum Export_Processors426_Mode6
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