using Admin.Core;
using Admin.Events;
using Admin.Handlers450;
using Admin.Shared310;
using Admin.Validators336;
using Admin.Web;
using Auth.Events5;
using Billing.Contracts44;
using Common.Client;
using DataAccess.Shared486;
using Documents.Events451;
using Documents.Shared427;
using Export.Data6;
using Scheduling.Handlers;
using Scheduling.Processors25;
using Security.Mappers313;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;

namespace Billing.Client182
{
    public interface IBilling_Client182_Validator11
    {
        /// <summary>Processes the Billing_Client182_Validator11 operation.</summary>
        void ProcessBilling_Client182_Validator11();

        /// <summary>Validates the Billing_Client182_Validator11 state.</summary>
        bool ValidateBilling_Client182_Validator11();
    }

}