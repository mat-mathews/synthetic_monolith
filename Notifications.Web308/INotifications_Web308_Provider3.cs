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
    internal interface INotifications_Web308_Provider3
    {
        /// <summary>Processes the Notifications_Web308_Provider3 operation.</summary>
        void ProcessNotifications_Web308_Provider3();

        /// <summary>Validates the Notifications_Web308_Provider3 state.</summary>
        bool ValidateNotifications_Web308_Provider3();
    }

}