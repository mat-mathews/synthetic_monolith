using Admin.Api;
using Admin.Mappers;
using Admin.Processors35;
using Admin.Web46;
using Auth.Models236;
using BatchJobs.Processors410;
using Common.Shared95;
using DataAccess.Handlers;
using Documents.Api129;
using Documents.Events;
using Documents.Processors133;
using GalaxyWorks.Client;
using GalaxyWorks.Handlers84;
using Import.Data193;
using Logging.Contracts74;
using Portal.Events139;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts228;
using Utilities.Data415;

namespace Billing.Shared312
{
    public interface IBilling_Shared312_Provider4
    {
        /// <summary>Processes the Billing_Shared312_Provider4 operation.</summary>
        void ProcessBilling_Shared312_Provider4();

        /// <summary>Validates the Billing_Shared312_Provider4 state.</summary>
        bool ValidateBilling_Shared312_Provider4();
    }

}