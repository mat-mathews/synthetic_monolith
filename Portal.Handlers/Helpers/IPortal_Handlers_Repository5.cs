using Admin.Shared;
using Admin.Validators37;
using Admin.Web46;
using Billing.Mappers198;
using DataAccess.Tests;
using Documents.Web164;
using Export.Core168;
using Export.Data150;
using Export.Web229;
using GalaxyWorks.Core309;
using Notifications.Data446;
using Portal.Events;
using Reporting.Contracts;
using Reporting.Processors326;
using Scheduling.Events;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client47;

namespace Portal.Handlers
{
    internal interface IPortal_Handlers_Repository5
    {
        /// <summary>Processes the Portal_Handlers_Repository5 operation.</summary>
        void ProcessPortal_Handlers_Repository5();

        /// <summary>Validates the Portal_Handlers_Repository5 state.</summary>
        bool ValidatePortal_Handlers_Repository5();
    }

}