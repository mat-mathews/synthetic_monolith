using Admin.Handlers447;
using Auth.Client249;
using Auth.Contracts402;
using Auth.Models23;
using Auth.Processors400;
using Billing.Processors259;
using Common.Contracts;
using Common.Mappers190;
using Documents.Tests;
using Documents.Tests171;
using GalaxyWorks.Data96;
using Integration.Contracts;
using Integration.Models;
using Logging.Core159;
using Notifications.Data446;
using Reporting.Client146;
using Reporting.Processors;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Validators
{
    internal interface ICommon_Validators_Service6
    {
        /// <summary>Processes the Common_Validators_Service6 operation.</summary>
        void ProcessCommon_Validators_Service6();

        /// <summary>Validates the Common_Validators_Service6 state.</summary>
        bool ValidateCommon_Validators_Service6();
    }

}