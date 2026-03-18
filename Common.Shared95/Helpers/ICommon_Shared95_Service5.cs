using Admin.Events306;
using Admin.Handlers;
using Admin.Models199;
using BatchJobs.Api;
using Billing.Events;
using Common.Service258;
using GalaxyWorks.Web;
using Imaging.Models459;
using Import.Tests;
using Integration.Processors248;
using Notifications.Mappers110;
using Portal.Events151;
using Portal.Validators;
using Scheduling.Events;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Common.Shared95
{
    internal interface ICommon_Shared95_Service5
    {
        /// <summary>Processes the Common_Shared95_Service5 operation.</summary>
        void ProcessCommon_Shared95_Service5();

        /// <summary>Validates the Common_Shared95_Service5 state.</summary>
        bool ValidateCommon_Shared95_Service5();
    }

}