using Admin.Shared310;
using Auth.Core2;
using Auth.Mappers;
using Billing.Service432;
using DataAccess.Tests282;
using Export.Core386;
using Export.Processors468;
using Import.Client356;
using Portal.Models;
using Reporting.Web105;
using Scheduling.Shared39;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;
using Utilities.Models41;
using Utilities.Web;
using Workflow.Client;

namespace Notifications.Service475
{
    /// <summary>Defines the possible states for Notifications_Service475_Type6.</summary>
    internal enum Notifications_Service475_Type6
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