using Admin.Contracts;
using Admin.Data408;
using Admin.Handlers61;
using Admin.Service339;
using Admin.Web154;
using Billing.Processors103;
using Billing.Validators305;
using Common.Validators;
using Export.Core168;
using Export.Tests62;
using GalaxyWorks.Data263;
using GalaxyWorks.Tests;
using Integration.Validators369;
using Notifications.Mappers110;
using Notifications.Shared;
using Reporting.Mappers;
using Reporting.Tests226;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service;

namespace Reporting.Handlers
{
    internal interface IReporting_Handlers_Repository5
    {
        /// <summary>Processes the Reporting_Handlers_Repository5 operation.</summary>
        void ProcessReporting_Handlers_Repository5();

        /// <summary>Validates the Reporting_Handlers_Repository5 state.</summary>
        bool ValidateReporting_Handlers_Repository5();
    }

}