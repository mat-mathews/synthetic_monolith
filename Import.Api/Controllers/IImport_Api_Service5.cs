using Admin.Models199;
using Admin.Models476;
using Auth.Core;
using Auth.Data;
using BatchJobs.Core11;
using Billing.Events;
using Common.Processors245;
using DataAccess.Core;
using DataAccess.Tests282;
using Export.Web130;
using GalaxyWorks.Shared437;
using Imaging.Mappers275;
using Import.Processors412;
using Logging.Api316;
using Scheduling.Api;
using Scheduling.Core273;
using Scheduling.Processors;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Api
{
    public interface IImport_Api_Service5
    {
        /// <summary>Processes the Import_Api_Service5 operation.</summary>
        void ProcessImport_Api_Service5();

        /// <summary>Validates the Import_Api_Service5 state.</summary>
        bool ValidateImport_Api_Service5();
    }

}