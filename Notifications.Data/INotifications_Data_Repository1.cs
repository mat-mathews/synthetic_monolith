using Auth.Contracts395;
using Auth.Handlers281;
using Auth.Processors;
using Billing.Shared;
using Common.Client53;
using DataAccess.Web;
using Documents.Data419;
using Documents.Web;
using Export.Client13;
using Notifications.Data406;
using Portal.Mappers;
using Scheduling.Web19;
using Security.Data278;
using Security.Service;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api;
using Workflow.Web;

namespace Notifications.Data
{
    internal interface INotifications_Data_Repository1
    {
        /// <summary>Processes the Notifications_Data_Repository1 operation.</summary>
        void ProcessNotifications_Data_Repository1();

        /// <summary>Validates the Notifications_Data_Repository1 state.</summary>
        bool ValidateNotifications_Data_Repository1();
    }

}