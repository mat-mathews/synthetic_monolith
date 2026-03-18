using Admin.Core;
using Auth.Handlers467;
using Auth.Processors319;
using BatchJobs.Web;
using Billing.Processors259;
using Common.Api213;
using Common.Web488;
using Documents.Contracts;
using Export.Client;
using Export.Service30;
using Imaging.Events;
using Import.Client7;
using Integration.Service107;
using Logging.Data29;
using Logging.Service382;
using Reporting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Web
{
    internal interface IIntegration_Web_Handler3
    {
        /// <summary>Processes the Integration_Web_Handler3 operation.</summary>
        void ProcessIntegration_Web_Handler3();

        /// <summary>Validates the Integration_Web_Handler3 state.</summary>
        bool ValidateIntegration_Web_Handler3();
    }

}