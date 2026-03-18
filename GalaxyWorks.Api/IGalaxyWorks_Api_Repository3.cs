using Admin.Client;
using Admin.Contracts;
using Admin.Mappers324;
using Auth.Events78;
using BatchJobs.Core11;
using Common.Client;
using Common.Shared297;
using Common.Validators430;
using Common.Web438;
using GalaxyWorks.Data96;
using GalaxyWorks.Models219;
using Import.Api314;
using Notifications.Validators391;
using Portal.Api123;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client351;

namespace GalaxyWorks.Api
{
    internal interface IGalaxyWorks_Api_Repository3
    {
        /// <summary>Processes the GalaxyWorks_Api_Repository3 operation.</summary>
        void ProcessGalaxyWorks_Api_Repository3();

        /// <summary>Validates the GalaxyWorks_Api_Repository3 state.</summary>
        bool ValidateGalaxyWorks_Api_Repository3();
    }

}