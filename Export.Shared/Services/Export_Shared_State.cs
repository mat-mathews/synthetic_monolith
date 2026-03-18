using Admin.Handlers447;
using Admin.Shared310;
using Auth.Shared325;
using Billing.Validators;
using Common.Api213;
using Common.Data;
using Common.Processors245;
using Export.Web229;
using GalaxyWorks.Processors;
using GalaxyWorks.Web;
using Import.Client64;
using Import.Mappers56;
using Integration.Processors;
using Logging.Client405;
using Logging.Shared;
using Portal.Processors389;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Shared
{
    /// <summary>Defines the possible states for Export_Shared_State.</summary>
    internal enum Export_Shared_State
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