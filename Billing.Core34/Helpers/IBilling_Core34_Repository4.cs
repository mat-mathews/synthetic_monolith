using Admin.Handlers61;
using Admin.Mappers;
using Admin.Shared14;
using Auth.Client249;
using Auth.Contracts402;
using Auth.Handlers467;
using Auth.Shared325;
using Billing.Processors;
using Billing.Tests;
using Documents.Core;
using Documents.Processors133;
using GalaxyWorks.Tests;
using Import.Api314;
using Integration.Contracts290;
using Logging.Contracts74;
using Notifications.Processors;
using Reporting.Api393;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Core34
{
    public interface IBilling_Core34_Repository4
    {
        /// <summary>Processes the Billing_Core34_Repository4 operation.</summary>
        void ProcessBilling_Core34_Repository4();

        /// <summary>Validates the Billing_Core34_Repository4 state.</summary>
        bool ValidateBilling_Core34_Repository4();
    }

}