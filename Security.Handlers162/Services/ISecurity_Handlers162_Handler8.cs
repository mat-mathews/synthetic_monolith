using Auth.Data;
using BatchJobs.Processors500;
using Billing.Client;
using Billing.Models;
using Billing.Processors259;
using Billing.Shared;
using Common.Client;
using Common.Core169;
using Common.Tests350;
using DataAccess.Validators;
using GalaxyWorks.Processors16;
using Import.Core;
using Logging.Tests292;
using Portal.Contracts181;
using Scheduling.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;

namespace Security.Handlers162
{
    internal interface ISecurity_Handlers162_Handler8
    {
        /// <summary>Processes the Security_Handlers162_Handler8 operation.</summary>
        void ProcessSecurity_Handlers162_Handler8();

        /// <summary>Validates the Security_Handlers162_Handler8 state.</summary>
        bool ValidateSecurity_Handlers162_Handler8();
    }

}