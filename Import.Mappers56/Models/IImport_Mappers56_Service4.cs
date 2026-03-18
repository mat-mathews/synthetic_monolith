using Auth.Api143;
using Auth.Client38;
using Auth.Processors411;
using Billing.Data;
using Billing.Validators;
using Documents.Validators;
using Export.Api49;
using Export.Mappers;
using GalaxyWorks.Service;
using Import.Client65;
using Import.Data100;
using Integration.Events;
using Notifications.Data;
using Portal.Api51;
using Scheduling.Client187;
using Scheduling.Contracts425;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Mappers56
{
    internal interface IImport_Mappers56_Service4
    {
        /// <summary>Processes the Import_Mappers56_Service4 operation.</summary>
        void ProcessImport_Mappers56_Service4();

        /// <summary>Validates the Import_Mappers56_Service4 state.</summary>
        bool ValidateImport_Mappers56_Service4();
    }

}