using Admin.Handlers447;
using Admin.Processors35;
using Admin.Web4;
using Auth.Models236;
using BatchJobs.Events;
using Common.Validators430;
using Documents.Shared334;
using Export.Mappers;
using Export.Models;
using Imaging.Api;
using Imaging.Validators;
using Import.Web;
using Integration.Core;
using Portal.Api;
using Portal.Handlers;
using Portal.Processors389;
using Security.Api320;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;

namespace GalaxyWorks.Events77
{
    internal interface IGalaxyWorks_Events77_Validator2
    {
        /// <summary>Processes the GalaxyWorks_Events77_Validator2 operation.</summary>
        void ProcessGalaxyWorks_Events77_Validator2();

        /// <summary>Validates the GalaxyWorks_Events77_Validator2 state.</summary>
        bool ValidateGalaxyWorks_Events77_Validator2();
    }

}