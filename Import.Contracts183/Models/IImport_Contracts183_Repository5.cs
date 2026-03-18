using Admin.Models199;
using Admin.Service456;
using Admin.Validators431;
using Auth.Api143;
using Auth.Client38;
using BatchJobs.Data176;
using Billing.Api497;
using DataAccess.Processors;
using Documents.Data;
using Documents.Data68;
using Export.Client;
using Integration.Api;
using Notifications.Events42;
using Reporting.Client422;
using Reporting.Events317;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;

namespace Import.Contracts183
{
    internal interface IImport_Contracts183_Repository5
    {
        /// <summary>Processes the Import_Contracts183_Repository5 operation.</summary>
        void ProcessImport_Contracts183_Repository5();

        /// <summary>Validates the Import_Contracts183_Repository5 state.</summary>
        bool ValidateImport_Contracts183_Repository5();
    }

}