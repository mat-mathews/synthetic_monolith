using Admin.Data465;
using Admin.Models199;
using Auth.Client249;
using Auth.Processors319;
using BatchJobs.Core11;
using Billing.Client182;
using Common.Data81;
using Documents.Data484;
using Documents.Events451;
using Documents.Models;
using Export.Processors361;
using GalaxyWorks.Contracts94;
using Imaging.Events416;
using Import.Web;
using Notifications.Mappers55;
using Notifications.Models277;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Service
{
    /// <summary>Defines the possible states for Notifications_Service_State2.</summary>
    public enum Notifications_Service_State2
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