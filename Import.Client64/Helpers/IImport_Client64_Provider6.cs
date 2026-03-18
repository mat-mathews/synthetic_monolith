using Admin.Handlers;
using Admin.Processors;
using Admin.Validators37;
using Admin.Web;
using Billing.Api497;
using Common.Api213;
using DataAccess.Tests;
using DataAccess.Validators88;
using Documents.Validators;
using Documents.Validators102;
using Export.Contracts;
using Integration.Contracts290;
using Integration.Mappers242;
using Notifications.Client;
using Notifications.Data348;
using Notifications.Service165;
using Notifications.Web90;
using Portal.Tests323;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Client64
{
    public interface IImport_Client64_Provider6
    {
        /// <summary>Processes the Import_Client64_Provider6 operation.</summary>
        void ProcessImport_Client64_Provider6();

        /// <summary>Validates the Import_Client64_Provider6 state.</summary>
        bool ValidateImport_Client64_Provider6();
    }

}