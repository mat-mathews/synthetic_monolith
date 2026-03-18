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
    internal interface INotifications_Handlers_Service2
    {
        /// <summary>Processes the Notifications_Handlers_Service2 operation.</summary>
        void ProcessNotifications_Handlers_Service2();

        /// <summary>Validates the Notifications_Handlers_Service2 state.</summary>
        bool ValidateNotifications_Handlers_Service2();
    }

}