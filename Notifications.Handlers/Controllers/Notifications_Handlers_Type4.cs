using Admin.Client;
using Admin.Data408;
using Admin.Shared363;
using Auth.Processors400;
using BatchJobs.Processors500;
using BatchJobs.Tests;
using Common.Data21;
using Imaging.Shared322;
using Import.Contracts296;
using Import.Models;
using Import.Processors472;
using Logging.Api316;
using Notifications.Web;
using Reporting.Core;
using Reporting.Handlers347;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;

namespace Notifications.Handlers
{
    /// <summary>Defines the possible states for Notifications_Handlers_Type4.</summary>
    public enum Notifications_Handlers_Type4
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