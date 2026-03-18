using Admin.Data;
using Auth.Core;
using BatchJobs.Handlers;
using Billing.Core191;
using Billing.Tests;
using DataAccess.Validators254;
using DataAccess.Web;
using Export.Api;
using Export.Web229;
using Imaging.Events416;
using Import.Client7;
using Import.Processors472;
using Logging.Client405;
using Logging.Events289;
using Security.Client137;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;

namespace Logging.Api316
{
    public interface ILogging_Api316_Validator10
    {
        /// <summary>Processes the Logging_Api316_Validator10 operation.</summary>
        void ProcessLogging_Api316_Validator10();

        /// <summary>Validates the Logging_Api316_Validator10 state.</summary>
        bool ValidateLogging_Api316_Validator10();
    }

}