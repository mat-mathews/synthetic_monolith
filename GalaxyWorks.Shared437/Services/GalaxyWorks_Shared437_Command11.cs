using Admin.Core121;
using Admin.Models199;
using Admin.Validators336;
using Auth.Contracts;
using BatchJobs.Mappers;
using Billing.Client491;
using DataAccess.Events;
using DataAccess.Tests286;
using Export.Service205;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Core;
using Import.Events;
using Integration.Handlers244;
using Logging.Handlers141;
using Notifications.Data446;
using Scheduling.Web264;
using Security.Processors295;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;

namespace GalaxyWorks.Shared437
{
    /// <summary>Immutable data transfer record for GalaxyWorks_Shared437_Command11.</summary>
    internal record GalaxyWorks_Shared437_Command11(string Value, int Count, DateTime Timestamp);

}