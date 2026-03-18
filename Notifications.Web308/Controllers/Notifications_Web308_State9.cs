using Admin.Client346;
using Auth.Mappers206;
using Auth.Shared;
using BatchJobs.Client;
using Common.Core118;
using Common.Validators430;
using Documents.Api439;
using Documents.Tests171;
using GalaxyWorks.Models;
using GalaxyWorks.Service293;
using GalaxyWorks.Validators;
using Imaging.Shared;
using Logging.Events289;
using Notifications.Validators252;
using Reporting.Data;
using Scheduling.Web;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Web308
{
    /// <summary>Defines the possible states for Notifications_Web308_State9.</summary>
    public enum Notifications_Web308_State9
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class Web308Context : DbContext
    {
    }

}