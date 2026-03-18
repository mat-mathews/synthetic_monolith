using Admin.Handlers447;
using Admin.Processors;
using Auth.Api;
using Auth.Contracts395;
using Auth.Core2;
using BatchJobs.Core;
using Billing.Api;
using Billing.Mappers;
using DataAccess.Client113;
using DataAccess.Validators88;
using Export.Handlers202;
using Integration.Service147;
using Notifications.Mappers;
using Notifications.Service475;
using Reporting.Tests;
using Scheduling.Shared;
using Scheduling.Tests85;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Events
{
    public interface IUtilities_Events_Repository5
    {
        /// <summary>Processes the Utilities_Events_Repository5 operation.</summary>
        void ProcessUtilities_Events_Repository5();

        /// <summary>Validates the Utilities_Events_Repository5 state.</summary>
        bool ValidateUtilities_Events_Repository5();
    }

}