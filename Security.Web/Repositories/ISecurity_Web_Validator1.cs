using Admin.Events;
using Admin.Service456;
using Auth.Contracts402;
using Auth.Tests;
using BatchJobs.Mappers362;
using Billing.Api497;
using Common.Web438;
using Export.Models;
using GalaxyWorks.Shared;
using Integration.Models;
using Logging.Shared315;
using Reporting.Validators;
using Security.Client353;
using Security.Core274;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;
using Workflow.Handlers;

namespace Security.Web
{
    public interface ISecurity_Web_Validator1
    {
        /// <summary>Processes the Security_Web_Validator1 operation.</summary>
        void ProcessSecurity_Web_Validator1();

        /// <summary>Validates the Security_Web_Validator1 state.</summary>
        bool ValidateSecurity_Web_Validator1();
    }

}