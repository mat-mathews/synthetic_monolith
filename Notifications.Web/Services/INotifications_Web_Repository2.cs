using Admin.Contracts;
using Auth.Client38;
using Auth.Handlers467;
using Auth.Mappers;
using Auth.Models23;
using Auth.Processors411;
using Billing.Core191;
using DataAccess.Tests;
using Export.Validators152;
using GalaxyWorks.Api390;
using Import.Handlers;
using Integration.Web;
using Reporting.Service207;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;
using Workflow.Validators201;
using Workflow.Web59;

namespace Notifications.Web
{
    public interface INotifications_Web_Repository2
    {
        /// <summary>Processes the Notifications_Web_Repository2 operation.</summary>
        void ProcessNotifications_Web_Repository2();

        /// <summary>Validates the Notifications_Web_Repository2 state.</summary>
        bool ValidateNotifications_Web_Repository2();
    }

}