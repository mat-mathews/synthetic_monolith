using Admin.Handlers450;
using Admin.Validators;
using Auth.Contracts402;
using BatchJobs.Service;
using Billing.Contracts;
using Billing.Validators;
using DataAccess.Core;
using Documents.Api129;
using Documents.Web;
using Export.Service205;
using Export.Tests62;
using Imaging.Models;
using Import.Models;
using Portal.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers197;
using Utilities.Validators;
using Workflow.Data;

namespace Import.Models457
{
    internal interface IImport_Models457_Repository9
    {
        /// <summary>Processes the Import_Models457_Repository9 operation.</summary>
        void ProcessImport_Models457_Repository9();

        /// <summary>Validates the Import_Models457_Repository9 state.</summary>
        bool ValidateImport_Models457_Repository9();
    }

}