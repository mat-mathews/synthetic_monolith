using Admin.Data408;
using Admin.Handlers450;
using Admin.Shared;
using Auth.Core140;
using Auth.Mappers28;
using BatchJobs.Client109;
using Billing.Contracts44;
using Billing.Core191;
using Common.Handlers;
using DataAccess.Api454;
using GalaxyWorks.Service293;
using Import.Service496;
using Portal.Service231;
using Scheduling.Data;
using Scheduling.Tests85;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers462;
using Utilities.Shared;
using Workflow.Client351;

namespace Import.Handlers
{
    public interface IImport_Handlers_Service2
    {
        /// <summary>Processes the Import_Handlers_Service2 operation.</summary>
        void ProcessImport_Handlers_Service2();

        /// <summary>Validates the Import_Handlers_Service2 state.</summary>
        bool ValidateImport_Handlers_Service2();
    }

}