using Admin.Api;
using Admin.Shared310;
using Admin.Validators336;
using Admin.Web4;
using Auth.Mappers;
using Auth.Mappers28;
using Common.Events280;
using Documents.Events451;
using Documents.Processors300;
using Export.Processors104;
using Export.Web130;
using Export.Web229;
using Logging.Web;
using Reporting.Contracts;
using Reporting.Shared394;
using Reporting.Tests226;
using Security.Client349;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Handlers
{
    internal interface IBilling_Handlers_Factory3
    {
        /// <summary>Processes the Billing_Handlers_Factory3 operation.</summary>
        void ProcessBilling_Handlers_Factory3();

        /// <summary>Validates the Billing_Handlers_Factory3 state.</summary>
        bool ValidateBilling_Handlers_Factory3();
    }

}