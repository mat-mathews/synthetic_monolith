using Admin.Client177;
using Admin.Client346;
using Admin.Service364;
using Auth.Models23;
using BatchJobs.Client109;
using BatchJobs.Service;
using Billing.Api497;
using Billing.Client182;
using Documents.Handlers;
using Import.Core;
using Notifications.Handlers;
using Notifications.Mappers110;
using Portal.Service;
using Portal.Shared;
using Reporting.Tests226;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;
using Workflow.Web59;

namespace Import.Contracts
{
    public interface IImport_Contracts_Provider2
    {
        /// <summary>Processes the Import_Contracts_Provider2 operation.</summary>
        void ProcessImport_Contracts_Provider2();

        /// <summary>Validates the Import_Contracts_Provider2 state.</summary>
        bool ValidateImport_Contracts_Provider2();
    }

}