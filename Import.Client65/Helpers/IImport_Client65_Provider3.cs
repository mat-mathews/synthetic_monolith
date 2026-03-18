using Admin.Data;
using Admin.Events235;
using Admin.Shared363;
using Admin.Validators336;
using Auth.Mappers;
using Billing.Shared149;
using Common.Core118;
using Common.Core417;
using Common.Shared;
using DataAccess.Api307;
using Import.Validators;
using Logging.Models436;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Utilities.Mappers232;
using Workflow.Api;
using Workflow.Api148;

namespace Import.Client65
{
    internal interface IImport_Client65_Provider3
    {
        /// <summary>Processes the Import_Client65_Provider3 operation.</summary>
        void ProcessImport_Client65_Provider3();

        /// <summary>Validates the Import_Client65_Provider3 state.</summary>
        bool ValidateImport_Client65_Provider3();
    }

}