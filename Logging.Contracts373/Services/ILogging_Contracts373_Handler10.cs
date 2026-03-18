using Admin.Handlers447;
using Admin.Shared14;
using Auth.Core2;
using BatchJobs.Core;
using Billing.Core;
using Billing.Handlers;
using Billing.Validators305;
using Documents.Api156;
using Documents.Handlers;
using Documents.Processors;
using Imaging.Mappers;
using Integration.Tests92;
using Logging.Web;
using Portal.Api99;
using Reporting.Processors495;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Workflow.Api;

namespace Logging.Contracts373
{
    internal interface ILogging_Contracts373_Handler10
    {
        /// <summary>Processes the Logging_Contracts373_Handler10 operation.</summary>
        void ProcessLogging_Contracts373_Handler10();

        /// <summary>Validates the Logging_Contracts373_Handler10 state.</summary>
        bool ValidateLogging_Contracts373_Handler10();
    }

}