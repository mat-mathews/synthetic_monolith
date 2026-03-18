using Admin.Api255;
using Admin.Client346;
using Auth.Models236;
using Auth.Processors;
using Auth.Shared;
using BatchJobs.Core11;
using GalaxyWorks.Api;
using GalaxyWorks.Mappers;
using GalaxyWorks.Mappers403;
using GalaxyWorks.Shared437;
using Integration.Models;
using Notifications.Core;
using Portal.Api352;
using Portal.Events151;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Shared114;
using Utilities.Web40;

namespace Notifications.Web90
{
    internal interface INotifications_Web90_Provider7
    {
        /// <summary>Processes the Notifications_Web90_Provider7 operation.</summary>
        void ProcessNotifications_Web90_Provider7();

        /// <summary>Validates the Notifications_Web90_Provider7 state.</summary>
        bool ValidateNotifications_Web90_Provider7();
    }

}