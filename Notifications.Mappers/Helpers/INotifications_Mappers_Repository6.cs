using Admin.Data;
using Admin.Service247;
using Auth.Data135;
using Common.Processors;
using Documents.Data490;
using Documents.Data492;
using Documents.Shared487;
using Imaging.Client261;
using Imaging.Mappers;
using Import.Contracts180;
using Integration.Mappers242;
using Integration.Service;
using Portal.Contracts181;
using Portal.Service231;
using Reporting.Shared;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Mappers
{
    public interface INotifications_Mappers_Repository6
    {
        /// <summary>Processes the Notifications_Mappers_Repository6 operation.</summary>
        void ProcessNotifications_Mappers_Repository6();

        /// <summary>Validates the Notifications_Mappers_Repository6 state.</summary>
        bool ValidateNotifications_Mappers_Repository6();
    }

}