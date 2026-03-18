using Admin.Mappers324;
using Admin.Service;
using Admin.Shared14;
using Auth.Contracts;
using Auth.Contracts395;
using Auth.Core2;
using BatchJobs.Client109;
using BatchJobs.Models329;
using Billing.Processors103;
using Common.Client;
using Common.Events;
using DataAccess.Handlers482;
using Import.Events493;
using Integration.Shared;
using Integration.Validators369;
using Notifications.Handlers;
using Notifications.Web90;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Mappers124
{
    internal interface IBilling_Mappers124_Factory8
    {
        /// <summary>Processes the Billing_Mappers124_Factory8 operation.</summary>
        void ProcessBilling_Mappers124_Factory8();

        /// <summary>Validates the Billing_Mappers124_Factory8 state.</summary>
        bool ValidateBilling_Mappers124_Factory8();
    }

}