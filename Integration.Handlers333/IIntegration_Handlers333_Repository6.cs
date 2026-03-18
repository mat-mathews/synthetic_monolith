using Admin.Data117;
using Admin.Web46;
using Auth.Client249;
using Auth.Handlers281;
using Billing.Mappers124;
using Billing.Shared149;
using Common.Service258;
using Documents.Events;
using Export.Processors111;
using Import.Handlers407;
using Import.Service429;
using Integration.Handlers17;
using Integration.Mappers;
using Integration.Models;
using Notifications.Handlers;
using Portal.Data266;
using Scheduling.Tests214;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Handlers333
{
    public interface IIntegration_Handlers333_Repository6
    {
        /// <summary>Processes the Integration_Handlers333_Repository6 operation.</summary>
        void ProcessIntegration_Handlers333_Repository6();

        /// <summary>Validates the Integration_Handlers333_Repository6 state.</summary>
        bool ValidateIntegration_Handlers333_Repository6();
    }

}