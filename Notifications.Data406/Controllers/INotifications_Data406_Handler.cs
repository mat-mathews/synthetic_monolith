using Admin.Api255;
using Admin.Contracts120;
using Auth.Handlers281;
using Auth.Models;
using BatchJobs.Core;
using BatchJobs.Mappers362;
using Billing.Processors388;
using DataAccess.Api341;
using Documents.Mappers;
using GalaxyWorks.Core309;
using Imaging.Models459;
using Notifications.Data348;
using Portal.Web;
using Scheduling.Tests;
using Scheduling.Tests76;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers462;
using Workflow.Validators;

namespace Notifications.Data406
{
    internal interface INotifications_Data406_Handler
    {
        /// <summary>Processes the Notifications_Data406_Handler operation.</summary>
        void ProcessNotifications_Data406_Handler();

        /// <summary>Validates the Notifications_Data406_Handler state.</summary>
        bool ValidateNotifications_Data406_Handler();
    }

}