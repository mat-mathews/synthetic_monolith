using Admin.Api255;
using Auth.Models23;
using Common.Handlers;
using Common.Shared297;
using GalaxyWorks.Mappers;
using Imaging.Mappers275;
using Imaging.Shared;
using Import.Client;
using Import.Core;
using Import.Handlers354;
using Integration.Processors;
using Portal.Service;
using Portal.Web158;
using Reporting.Client422;
using Reporting.Handlers347;
using Reporting.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Processors
{
    public interface INotifications_Processors_Provider1
    {
        /// <summary>Processes the Notifications_Processors_Provider1 operation.</summary>
        void ProcessNotifications_Processors_Provider1();

        /// <summary>Validates the Notifications_Processors_Provider1 state.</summary>
        bool ValidateNotifications_Processors_Provider1();
    }

}