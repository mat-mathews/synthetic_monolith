using Admin.Validators;
using Auth.Data135;
using Auth.Processors411;
using BatchJobs.Web;
using Billing.Mappers198;
using Billing.Mappers225;
using Documents.Shared;
using Import.Processors;
using Integration.Processors248;
using Portal.Api352;
using Portal.Handlers26;
using Portal.Service378;
using Scheduling.Processors80;
using Security.Service;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service;

namespace Notifications.Api144
{
    public interface INotifications_Api144_Validator6
    {
        /// <summary>Processes the Notifications_Api144_Validator6 operation.</summary>
        void ProcessNotifications_Api144_Validator6();

        /// <summary>Validates the Notifications_Api144_Validator6 state.</summary>
        bool ValidateNotifications_Api144_Validator6();
    }

}