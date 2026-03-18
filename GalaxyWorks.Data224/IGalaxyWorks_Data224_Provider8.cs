using Admin.Client177;
using Admin.Models;
using Auth.Contracts402;
using Documents.Models;
using Export.Service;
using Import.Api314;
using Integration.Service;
using Logging.Handlers141;
using Logging.Shared;
using Portal.Core8;
using Portal.Mappers;
using Portal.Tests;
using Reporting.Events;
using Scheduling.Api;
using Security.Events;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Data224
{
    internal interface IGalaxyWorks_Data224_Provider8
    {
        /// <summary>Processes the GalaxyWorks_Data224_Provider8 operation.</summary>
        void ProcessGalaxyWorks_Data224_Provider8();

        /// <summary>Validates the GalaxyWorks_Data224_Provider8 state.</summary>
        bool ValidateGalaxyWorks_Data224_Provider8();
    }

}