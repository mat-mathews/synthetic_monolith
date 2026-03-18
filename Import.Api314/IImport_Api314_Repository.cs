using Admin.Data;
using Auth.Client271;
using Auth.Data135;
using Auth.Handlers467;
using Auth.Processors;
using Billing.Core;
using DataAccess.Handlers;
using Documents.Processors133;
using Imaging.Models459;
using Import.Processors472;
using Import.Shared;
using Integration.Tests45;
using Logging.Data29;
using Logging.Validators359;
using Notifications.Events42;
using Notifications.Processors20;
using Portal.Events139;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Api314
{
    public interface IImport_Api314_Repository
    {
        /// <summary>Processes the Import_Api314_Repository operation.</summary>
        void ProcessImport_Api314_Repository();

        /// <summary>Validates the Import_Api314_Repository state.</summary>
        bool ValidateImport_Api314_Repository();
    }

}