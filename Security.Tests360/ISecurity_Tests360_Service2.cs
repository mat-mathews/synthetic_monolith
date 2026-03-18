using Admin.Core;
using Admin.Service;
using Auth.Api;
using BatchJobs.Core;
using Billing.Client;
using Billing.Shared384;
using Billing.Web;
using Common.Processors245;
using DataAccess.Validators409;
using Export.Processors361;
using GalaxyWorks.Validators;
using Import.Mappers;
using Logging.Tests;
using Notifications.Service475;
using Reporting.Api;
using Security.Client353;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Tests360
{
    internal interface ISecurity_Tests360_Service2
    {
        /// <summary>Processes the Security_Tests360_Service2 operation.</summary>
        void ProcessSecurity_Tests360_Service2();

        /// <summary>Validates the Security_Tests360_Service2 state.</summary>
        bool ValidateSecurity_Tests360_Service2();
    }

}