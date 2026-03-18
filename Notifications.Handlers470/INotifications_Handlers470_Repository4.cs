using Admin.Api255;
using Admin.Mappers;
using BatchJobs.Client;
using Billing.Processors259;
using Common.Client269;
using DataAccess.Events283;
using Export.Mappers237;
using Export.Models461;
using Imaging.Events416;
using Import.Core;
using Reporting.Api;
using Reporting.Events188;
using Scheduling.Validators;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service358;
using Workflow.Client;

namespace Notifications.Handlers470
{
    internal interface INotifications_Handlers470_Repository4
    {
        /// <summary>Processes the Notifications_Handlers470_Repository4 operation.</summary>
        void ProcessNotifications_Handlers470_Repository4();

        /// <summary>Validates the Notifications_Handlers470_Repository4 state.</summary>
        bool ValidateNotifications_Handlers470_Repository4();
    }

}