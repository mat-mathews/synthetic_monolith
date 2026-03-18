using Admin.Client;
using BatchJobs.Client267;
using Billing.Mappers225;
using Billing.Tests;
using DataAccess.Api341;
using Documents.Api;
using Imaging.Shared;
using Integration.Processors71;
using Logging.Service;
using Portal.Processors52;
using Portal.Validators227;
using Portal.Validators69;
using Scheduling.Core273;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web398;
using Workflow.Core;

namespace Import.Contracts131
{
    internal interface IImport_Contracts131_Validator4
    {
        /// <summary>Processes the Import_Contracts131_Validator4 operation.</summary>
        void ProcessImport_Contracts131_Validator4();

        /// <summary>Validates the Import_Contracts131_Validator4 state.</summary>
        bool ValidateImport_Contracts131_Validator4();
    }

}