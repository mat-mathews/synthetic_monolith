using Admin.Contracts;
using Admin.Service364;
using Auth.Contracts;
using Auth.Core;
using Billing.Client;
using DataAccess.Api307;
using DataAccess.Api454;
using DataAccess.Client82;
using Documents.Models;
using GalaxyWorks.Data375;
using Import.Shared;
using Logging.Shared;
using Portal.Mappers;
using Reporting.Events220;
using Security.Contracts238;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web377;

namespace Billing.Core191
{
    public interface IBilling_Core191_Repository1
    {
        /// <summary>Processes the Billing_Core191_Repository1 operation.</summary>
        void ProcessBilling_Core191_Repository1();

        /// <summary>Validates the Billing_Core191_Repository1 state.</summary>
        bool ValidateBilling_Core191_Repository1();
    }

}