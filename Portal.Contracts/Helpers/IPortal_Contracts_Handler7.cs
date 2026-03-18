using Admin.Validators431;
using Admin.Web;
using Auth.Data135;
using Auth.Mappers206;
using Auth.Processors;
using BatchJobs.Contracts399;
using Billing.Api497;
using Common.Data;
using Notifications.Web308;
using Reporting.Events317;
using Reporting.Handlers347;
using Reporting.Web105;
using Scheduling.Events;
using Security.Events288;
using Security.Service;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Handlers462;

namespace Portal.Contracts
{
    public interface IPortal_Contracts_Handler7
    {
        /// <summary>Processes the Portal_Contracts_Handler7 operation.</summary>
        void ProcessPortal_Contracts_Handler7();

        /// <summary>Validates the Portal_Contracts_Handler7 state.</summary>
        bool ValidatePortal_Contracts_Handler7();
    }

    public class ContractsContext : DbContext
    {
    }

}