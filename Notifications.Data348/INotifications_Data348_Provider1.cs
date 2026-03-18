using Admin.Contracts;
using Admin.Data;
using Auth.Core2;
using Auth.Handlers467;
using BatchJobs.Tests;
using BatchJobs.Validators;
using DataAccess.Shared189;
using Documents.Web;
using GalaxyWorks.Mappers;
using Imaging.Mappers93;
using Imaging.Tests;
using Import.Handlers354;
using Logging.Api316;
using Logging.Web;
using Scheduling.Mappers;
using Scheduling.Processors;
using Security.Api134;
using Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Data348
{
    internal interface INotifications_Data348_Provider1
    {
        /// <summary>Processes the Notifications_Data348_Provider1 operation.</summary>
        void ProcessNotifications_Data348_Provider1();

        /// <summary>Validates the Notifications_Data348_Provider1 state.</summary>
        bool ValidateNotifications_Data348_Provider1();
    }

}