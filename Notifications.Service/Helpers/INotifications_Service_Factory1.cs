using Admin.Data465;
using Admin.Models199;
using Auth.Client249;
using Auth.Processors319;
using BatchJobs.Core11;
using Billing.Client182;
using Common.Data81;
using Documents.Data484;
using Documents.Events451;
using Documents.Models;
using Export.Processors361;
using GalaxyWorks.Contracts94;
using Imaging.Events416;
using Import.Web;
using Notifications.Mappers55;
using Notifications.Models277;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Service
{
    public interface INotifications_Service_Factory1
    {
        /// <summary>Processes the Notifications_Service_Factory1 operation.</summary>
        void ProcessNotifications_Service_Factory1();

        /// <summary>Validates the Notifications_Service_Factory1 state.</summary>
        bool ValidateNotifications_Service_Factory1();
    }

}