using Admin.Client;
using Admin.Handlers;
using Admin.Shared310;
using Admin.Web46;
using Auth.Api143;
using BatchJobs.Models304;
using Billing.Core;
using Billing.Processors259;
using Export.Models;
using GalaxyWorks.Api;
using GalaxyWorks.Models219;
using Imaging.Handlers;
using Integration.Client;
using Logging.Handlers455;
using Notifications.Client257;
using Portal.Data216;
using Portal.Validators227;
using Security.Handlers162;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Validators430
{
    /// <summary>Defines the possible states for Common_Validators430_Level6.</summary>
    public enum Common_Validators430_Level6
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