using Admin.Processors35;
using Admin.Web4;
using Auth.Api;
using Auth.Client;
using Auth.Contracts;
using Billing.Client491;
using Billing.Handlers;
using DataAccess.Web;
using Documents.Mappers;
using Documents.Web;
using Export.Api12;
using Export.Models262;
using Export.Processors468;
using Import.Api272;
using Logging.Handlers285;
using Reporting.Events220;
using Reporting.Mappers239;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Handlers385
{
    internal interface IGalaxyWorks_Handlers385_Provider6
    {
        /// <summary>Processes the GalaxyWorks_Handlers385_Provider6 operation.</summary>
        void ProcessGalaxyWorks_Handlers385_Provider6();

        /// <summary>Validates the GalaxyWorks_Handlers385_Provider6 state.</summary>
        bool ValidateGalaxyWorks_Handlers385_Provider6();
    }

}