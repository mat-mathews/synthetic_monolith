using Admin.Shared310;
using Admin.Web;
using Billing.Mappers124;
using Billing.Tests;
using DataAccess.Validators;
using Documents.Service;
using Import.Api272;
using Import.Client65;
using Integration.Api469;
using Logging.Data;
using Logging.Validators;
using Notifications.Shared380;
using Notifications.Tests;
using Reporting.Tests67;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Billing.Shared
{
    public interface IBilling_Shared_Validator2
    {
        /// <summary>Processes the Billing_Shared_Validator2 operation.</summary>
        void ProcessBilling_Shared_Validator2();

        /// <summary>Validates the Billing_Shared_Validator2 state.</summary>
        bool ValidateBilling_Shared_Validator2();
    }

}