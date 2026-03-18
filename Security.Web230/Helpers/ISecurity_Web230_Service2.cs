using Admin.Service;
using Auth.Client38;
using Auth.Contracts;
using Auth.Data135;
using Auth.Mappers178;
using Billing.Contracts;
using Common.Api57;
using Common.Mappers;
using GalaxyWorks.Handlers;
using GalaxyWorks.Mappers;
using Import.Mappers56;
using Logging.Api;
using Portal.Data;
using Portal.Tests323;
using Scheduling.Processors80;
using Scheduling.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Security.Web230
{
    public interface ISecurity_Web230_Service2
    {
        /// <summary>Processes the Security_Web230_Service2 operation.</summary>
        void ProcessSecurity_Web230_Service2();

        /// <summary>Validates the Security_Web230_Service2 state.</summary>
        bool ValidateSecurity_Web230_Service2();
    }

}