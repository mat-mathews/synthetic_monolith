using Admin.Client177;
using Admin.Models199;
using Admin.Service247;
using Admin.Web;
using Billing.Api9;
using Common.Core;
using Common.Core118;
using GalaxyWorks.Events;
using Integration.Handlers;
using Logging.Client;
using Notifications.Models;
using Notifications.Service165;
using Notifications.Service475;
using Portal.Events151;
using Security.Core274;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;

namespace Import.Shared
{
    internal interface IImport_Shared_Provider4
    {
        /// <summary>Processes the Import_Shared_Provider4 operation.</summary>
        void ProcessImport_Shared_Provider4();

        /// <summary>Validates the Import_Shared_Provider4 state.</summary>
        bool ValidateImport_Shared_Provider4();
    }

}