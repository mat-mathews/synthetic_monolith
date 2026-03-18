using Admin.Data;
using Admin.Models;
using Auth.Mappers28;
using Billing.Mappers198;
using Billing.Shared149;
using DataAccess.Data36;
using Export.Client13;
using Export.Handlers202;
using Export.Models262;
using Logging.Processors;
using Notifications.Events;
using Notifications.Models;
using Reporting.Contracts;
using Reporting.Processors;
using Reporting.Service;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Tests
{
    public interface IPortal_Tests_Provider2
    {
        /// <summary>Processes the Portal_Tests_Provider2 operation.</summary>
        void ProcessPortal_Tests_Provider2();

        /// <summary>Validates the Portal_Tests_Provider2 state.</summary>
        bool ValidatePortal_Tests_Provider2();
    }

}