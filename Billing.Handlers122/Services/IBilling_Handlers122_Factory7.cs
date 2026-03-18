using Admin.Events;
using Admin.Tests10;
using Auth.Client271;
using Auth.Mappers206;
using BatchJobs.Handlers;
using Billing.Tests;
using Common.Handlers;
using DataAccess.Models;
using Documents.Api129;
using Documents.Events;
using Documents.Tests171;
using Export.Events;
using Imaging.Shared115;
using Import.Events493;
using Logging.Events;
using Logging.Handlers368;
using Portal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Billing.Handlers122
{
    public interface IBilling_Handlers122_Factory7
    {
        /// <summary>Processes the Billing_Handlers122_Factory7 operation.</summary>
        void ProcessBilling_Handlers122_Factory7();

        /// <summary>Validates the Billing_Handlers122_Factory7 state.</summary>
        bool ValidateBilling_Handlers122_Factory7();
    }

}