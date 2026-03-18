using Admin.Mappers;
using Admin.Validators;
using Auth.Data;
using Billing.Models;
using Common.Validators50;
using DataAccess.Processors;
using Export.Contracts;
using GalaxyWorks.Validators;
using Import.Client356;
using Logging.Core;
using Notifications.Data;
using Portal.Contracts181;
using Reporting.Api287;
using Reporting.Validators;
using Scheduling.Handlers43;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;

namespace Security.Service
{
    internal interface ISecurity_Service_Provider8
    {
        /// <summary>Processes the Security_Service_Provider8 operation.</summary>
        void ProcessSecurity_Service_Provider8();

        /// <summary>Validates the Security_Service_Provider8 state.</summary>
        bool ValidateSecurity_Service_Provider8();
    }

}