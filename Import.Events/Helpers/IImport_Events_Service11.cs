using Admin.Core121;
using Admin.Handlers447;
using Admin.Web4;
using BatchJobs.Api;
using BatchJobs.Contracts399;
using Common.Api213;
using Common.Validators;
using DataAccess.Service464;
using Export.Mappers;
using Export.Shared332;
using GalaxyWorks.Handlers84;
using Import.Events374;
using Integration.Processors248;
using Scheduling.Api185;
using Scheduling.Mappers442;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests27;

namespace Import.Events
{
    public interface IImport_Events_Service11
    {
        /// <summary>Processes the Import_Events_Service11 operation.</summary>
        void ProcessImport_Events_Service11();

        /// <summary>Validates the Import_Events_Service11 state.</summary>
        bool ValidateImport_Events_Service11();
    }

}