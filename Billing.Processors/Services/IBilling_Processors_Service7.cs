using Admin.Client177;
using Admin.Core;
using Admin.Models;
using Auth.Client;
using BatchJobs.Api;
using BatchJobs.Core;
using Common.Processors;
using Common.Tests350;
using Documents.Shared;
using Export.Processors361;
using GalaxyWorks.Api390;
using Imaging.Service;
using Import.Models457;
using Logging.Contracts;
using Logging.Contracts373;
using Notifications.Web90;
using Portal.Models413;
using Security.Client137;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Processors
{
    public interface IBilling_Processors_Service7
    {
        /// <summary>Processes the Billing_Processors_Service7 operation.</summary>
        void ProcessBilling_Processors_Service7();

        /// <summary>Validates the Billing_Processors_Service7 state.</summary>
        bool ValidateBilling_Processors_Service7();
    }

}