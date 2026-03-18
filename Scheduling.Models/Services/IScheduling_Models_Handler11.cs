using Admin.Data117;
using Auth.Api;
using Auth.Data135;
using BatchJobs.Core;
using BatchJobs.Validators311;
using Billing.Shared384;
using DataAccess.Api294;
using Documents.Shared;
using Export.Mappers;
using GalaxyWorks.Web;
using Integration.Service107;
using Integration.Tests92;
using Notifications.Handlers112;
using Notifications.Processors;
using Portal.Validators69;
using Reporting.Client146;
using Reporting.Client422;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public interface IScheduling_Models_Handler11
    {
        /// <summary>Processes the Scheduling_Models_Handler11 operation.</summary>
        void ProcessScheduling_Models_Handler11();

        /// <summary>Validates the Scheduling_Models_Handler11 state.</summary>
        bool ValidateScheduling_Models_Handler11();
    }

}