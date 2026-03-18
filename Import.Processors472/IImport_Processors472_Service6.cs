using Admin.Api;
using Auth.Handlers281;
using Common.Mappers190;
using DataAccess.Shared486;
using DataAccess.Web200;
using Export.Data344;
using Export.Service;
using GalaxyWorks.Data96;
using Import.Service496;
using Logging.Tests292;
using Logging.Validators359;
using Notifications.Processors20;
using Reporting.Api287;
using Security.Client137;
using Security.Core274;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;

namespace Import.Processors472
{
    public interface IImport_Processors472_Service6
    {
        /// <summary>Processes the Import_Processors472_Service6 operation.</summary>
        void ProcessImport_Processors472_Service6();

        /// <summary>Validates the Import_Processors472_Service6 state.</summary>
        bool ValidateImport_Processors472_Service6();
    }

}