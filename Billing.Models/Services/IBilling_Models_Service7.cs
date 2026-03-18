using Admin.Data408;
using Admin.Handlers447;
using Auth.Handlers467;
using Billing.Client;
using Common.Client269;
using Documents.Api;
using GalaxyWorks.Validators;
using Imaging.Handlers;
using Integration.Contracts290;
using Integration.Data;
using Integration.Processors;
using Notifications.Contracts;
using Notifications.Data446;
using Notifications.Mappers55;
using Portal.Service489;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Tests;
using Workflow.Handlers421;

namespace Billing.Models
{
    public interface IBilling_Models_Service7
    {
        /// <summary>Processes the Billing_Models_Service7 operation.</summary>
        void ProcessBilling_Models_Service7();

        /// <summary>Validates the Billing_Models_Service7 state.</summary>
        bool ValidateBilling_Models_Service7();
    }

}