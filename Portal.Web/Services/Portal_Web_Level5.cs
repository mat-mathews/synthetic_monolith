using Admin.Events235;
using Admin.Shared363;
using Auth.Events78;
using Auth.Models236;
using Billing.Processors388;
using DataAccess.Contracts203;
using Export.Core168;
using Export.Validators;
using Export.Validators152;
using Import.Handlers407;
using Import.Service291;
using Reporting.Client422;
using Reporting.Events317;
using Scheduling.Client;
using Scheduling.Web264;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;

namespace Portal.Web
{
    /// <summary>Defines the possible states for Portal_Web_Level5.</summary>
    public enum Portal_Web_Level5
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