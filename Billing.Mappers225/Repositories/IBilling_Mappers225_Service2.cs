using Admin.Data117;
using Admin.Models199;
using Admin.Shared;
using Auth.Mappers28;
using Documents.Service471;
using Export.Events163;
using Import.Client64;
using Integration.Handlers;
using Logging.Web;
using Notifications.Contracts;
using Notifications.Validators;
using Portal.Api51;
using Reporting.Api393;
using Scheduling.Core;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;

namespace Billing.Mappers225
{
    internal interface IBilling_Mappers225_Service2
    {
        /// <summary>Processes the Billing_Mappers225_Service2 operation.</summary>
        void ProcessBilling_Mappers225_Service2();

        /// <summary>Validates the Billing_Mappers225_Service2 state.</summary>
        bool ValidateBilling_Mappers225_Service2();
    }

}