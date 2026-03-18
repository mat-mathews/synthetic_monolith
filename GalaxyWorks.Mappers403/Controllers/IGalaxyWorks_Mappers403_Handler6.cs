using Admin.Api;
using Admin.Core;
using Auth.Mappers206;
using Auth.Models236;
using BatchJobs.Contracts;
using Billing.Core191;
using Billing.Service;
using Common.Service258;
using Documents.Api251;
using Documents.Events;
using Import.Api314;
using Integration.Tests45;
using Logging.Client405;
using Scheduling.Handlers63;
using Scheduling.Models441;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Web40;

namespace GalaxyWorks.Mappers403
{
    internal interface IGalaxyWorks_Mappers403_Handler6
    {
        /// <summary>Processes the GalaxyWorks_Mappers403_Handler6 operation.</summary>
        void ProcessGalaxyWorks_Mappers403_Handler6();

        /// <summary>Validates the GalaxyWorks_Mappers403_Handler6 state.</summary>
        bool ValidateGalaxyWorks_Mappers403_Handler6();
    }

}