using Admin.Client177;
using Auth.Client271;
using Auth.Handlers467;
using BatchJobs.Handlers443;
using Billing.Contracts44;
using Common.Contracts;
using Common.Data;
using Common.Processors142;
using Export.Web210;
using Import.Api179;
using Integration.Processors241;
using Integration.Service147;
using Notifications.Core166;
using Security.Client349;
using Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts192;
using Workflow.Handlers;

namespace Import.Mappers
{
    internal interface IImport_Mappers_Repository4
    {
        /// <summary>Processes the Import_Mappers_Repository4 operation.</summary>
        void ProcessImport_Mappers_Repository4();

        /// <summary>Validates the Import_Mappers_Repository4 state.</summary>
        bool ValidateImport_Mappers_Repository4();
    }

}