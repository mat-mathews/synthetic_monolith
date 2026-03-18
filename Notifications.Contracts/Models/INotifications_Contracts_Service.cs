using Admin.Contracts120;
using Admin.Service364;
using Auth.Core2;
using BatchJobs.Client;
using Common.Api;
using Common.Data126;
using Documents.Shared;
using Export.Events276;
using Export.Service205;
using Import.Contracts180;
using Import.Processors412;
using Integration.Processors71;
using Notifications.Shared396;
using Reporting.Api393;
using Reporting.Shared394;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;

namespace Notifications.Contracts
{
    internal interface INotifications_Contracts_Service
    {
        /// <summary>Processes the Notifications_Contracts_Service operation.</summary>
        void ProcessNotifications_Contracts_Service();

        /// <summary>Validates the Notifications_Contracts_Service state.</summary>
        bool ValidateNotifications_Contracts_Service();
    }

}