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
    internal struct GalaxyWorks_Shared437_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}