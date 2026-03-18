using Admin.Data117;
using Admin.Handlers;
using Admin.Web46;
using Auth.Client38;
using Auth.Mappers208;
using DataAccess.Api98;
using Export.Processors361;
using Import.Api179;
using Import.Contracts296;
using Integration.Contracts290;
using Notifications.Service475;
using Portal.Shared;
using Reporting.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;
using Utilities.Processors;
using Utilities.Tests;
using Workflow.Service161;
using Workflow.Tests;

namespace Import.Client356
{
    internal interface IImport_Client356_Repository5
    {
        /// <summary>Processes the Import_Client356_Repository5 operation.</summary>
        void ProcessImport_Client356_Repository5();

        /// <summary>Validates the Import_Client356_Repository5 state.</summary>
        bool ValidateImport_Client356_Repository5();
    }

}