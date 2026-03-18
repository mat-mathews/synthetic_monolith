using Auth.Client249;
using Auth.Events;
using Auth.Mappers208;
using Billing.Mappers;
using Common.Core;
using Common.Events280;
using Common.Processors245;
using Common.Service258;
using Documents.Processors133;
using Imaging.Tests;
using Import.Events;
using Notifications.Models277;
using Portal.Models413;
using Reporting.Processors326;
using Scheduling.Api3;
using Security.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts;

namespace Notifications.Models466
{
    internal interface INotifications_Models466_Handler5
    {
        /// <summary>Processes the Notifications_Models466_Handler5 operation.</summary>
        void ProcessNotifications_Models466_Handler5();

        /// <summary>Validates the Notifications_Models466_Handler5 state.</summary>
        bool ValidateNotifications_Models466_Handler5();
    }

}