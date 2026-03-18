using Admin.Events306;
using Admin.Handlers447;
using Billing.Api9;
using DataAccess.Data;
using Export.Core372;
using GalaxyWorks.Models;
using GalaxyWorks.Processors;
using Imaging.Tests328;
using Notifications.Service;
using Portal.Api99;
using Portal.Data266;
using Portal.Handlers;
using Reporting.Events;
using Scheduling.Data;
using Scheduling.Data54;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;

namespace Portal.Handlers26
{
    internal interface IPortal_Handlers26_Validator9
    {
        /// <summary>Processes the Portal_Handlers26_Validator9 operation.</summary>
        void ProcessPortal_Handlers26_Validator9();

        /// <summary>Validates the Portal_Handlers26_Validator9 state.</summary>
        bool ValidatePortal_Handlers26_Validator9();
    }

}