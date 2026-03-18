using Admin.Validators336;
using Auth.Contracts402;
using Auth.Shared;
using Billing.Client22;
using Export.Web210;
using Integration.Service147;
using Integration.Tests86;
using Notifications.Models;
using Portal.Shared;
using Portal.Web158;
using Scheduling.Mappers442;
using Scheduling.Processors;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;
using Utilities.Service;
using Workflow.Handlers;

namespace Portal.Processors389
{
    public interface IPortal_Processors389_Repository4
    {
        /// <summary>Processes the Portal_Processors389_Repository4 operation.</summary>
        void ProcessPortal_Processors389_Repository4();

        /// <summary>Validates the Portal_Processors389_Repository4 state.</summary>
        bool ValidatePortal_Processors389_Repository4();
    }

}