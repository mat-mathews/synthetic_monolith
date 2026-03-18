using Admin.Data;
using Auth.Data;
using Auth.Events78;
using Auth.Handlers467;
using Auth.Mappers208;
using Common.Events367;
using Common.Handlers;
using Common.Service;
using DataAccess.Api;
using Export.Data344;
using Export.Web130;
using GalaxyWorks.Tests;
using Integration.Client;
using Logging.Contracts74;
using Logging.Events;
using Portal.Api352;
using Portal.Events;
using Portal.Events151;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Shared
{
    internal interface IGalaxyWorks_Shared_Validator2
    {
        /// <summary>Processes the GalaxyWorks_Shared_Validator2 operation.</summary>
        void ProcessGalaxyWorks_Shared_Validator2();

        /// <summary>Validates the GalaxyWorks_Shared_Validator2 state.</summary>
        bool ValidateGalaxyWorks_Shared_Validator2();
    }

}