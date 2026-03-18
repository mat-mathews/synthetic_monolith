using Admin.Shared310;
using Auth.Client271;
using BatchJobs.Models;
using Common.Service258;
using DataAccess.Tests286;
using Documents.Tests;
using GalaxyWorks.Contracts94;
using Imaging.Mappers93;
using Import.Api272;
using Import.Processors472;
using Notifications.Handlers112;
using Notifications.Validators391;
using Portal.Api99;
using Reporting.Web345;
using Scheduling.Contracts;
using Scheduling.Core273;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Validators
{
    public interface IBilling_Validators_Handler1
    {
        /// <summary>Processes the Billing_Validators_Handler1 operation.</summary>
        void ProcessBilling_Validators_Handler1();

        /// <summary>Validates the Billing_Validators_Handler1 state.</summary>
        bool ValidateBilling_Validators_Handler1();
    }

}