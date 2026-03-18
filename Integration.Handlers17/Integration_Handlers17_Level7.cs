using Admin.Handlers;
using Auth.Data135;
using Auth.Events5;
using BatchJobs.Data176;
using Common.Service;
using DataAccess.Handlers;
using DataAccess.Tests286;
using Export.Models;
using Export.Service;
using Export.Web130;
using Integration.Data;
using Logging.Handlers368;
using Notifications.Service165;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;
using Workflow.Validators201;

namespace Integration.Handlers17
{
    /// <summary>Defines the possible states for Integration_Handlers17_Level7.</summary>
    public enum Integration_Handlers17_Level7
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