using Admin.Events235;
using Admin.Service339;
using Admin.Web154;
using Admin.Web46;
using Auth.Api;
using Auth.Client38;
using Billing.Handlers122;
using Common.Shared297;
using GalaxyWorks.Processors16;
using Import.Api;
using Import.Tests;
using Integration.Tests;
using Logging.Processors;
using Notifications.Tests;
using Portal.Tests481;
using Scheduling.Core;
using Scheduling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;

namespace Portal.Events151
{
    public interface IPortal_Events151_Provider1
    {
        /// <summary>Processes the Portal_Events151_Provider1 operation.</summary>
        void ProcessPortal_Events151_Provider1();

        /// <summary>Validates the Portal_Events151_Provider1 state.</summary>
        bool ValidatePortal_Events151_Provider1();
    }

}