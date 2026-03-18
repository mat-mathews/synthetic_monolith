using Admin.Shared;
using Admin.Validators;
using Auth.Client249;
using Billing.Core;
using Billing.Handlers122;
using Billing.Mappers;
using Billing.Processors;
using DataAccess.Client113;
using DataAccess.Validators88;
using Documents.Data492;
using Export.Client;
using Export.Web229;
using Import.Processors472;
using Notifications.Handlers112;
using Reporting.Api287;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Validators;

namespace Scheduling.Processors397
{
    internal interface IScheduling_Processors397_Validator9
    {
        /// <summary>Processes the Scheduling_Processors397_Validator9 operation.</summary>
        void ProcessScheduling_Processors397_Validator9();

        /// <summary>Validates the Scheduling_Processors397_Validator9 state.</summary>
        bool ValidateScheduling_Processors397_Validator9();
    }

}