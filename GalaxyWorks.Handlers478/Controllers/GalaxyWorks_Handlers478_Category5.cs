using Admin.Validators240;
using Admin.Web;
using Auth.Contracts;
using Auth.Mappers206;
using Billing.Api;
using Billing.Core;
using Billing.Processors388;
using Common.Core;
using Export.Processors426;
using GalaxyWorks.Contracts;
using GalaxyWorks.Mappers403;
using Imaging.Mappers275;
using Imaging.Models184;
using Import.Contracts131;
using Integration.Contracts;
using Logging.Data;
using Reporting.Events483;
using Reporting.Tests226;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Handlers478
{
    /// <summary>Defines the possible states for GalaxyWorks_Handlers478_Category5.</summary>
    internal enum GalaxyWorks_Handlers478_Category5
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