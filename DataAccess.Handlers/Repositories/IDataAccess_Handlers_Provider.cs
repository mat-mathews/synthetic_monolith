using Admin.Client;
using Admin.Web46;
using Auth.Client;
using Auth.Events;
using Auth.Mappers28;
using Auth.Processors319;
using Documents.Core357;
using Documents.Shared487;
using Imaging.Validators;
using Import.Shared;
using Integration.Data;
using Logging.Core159;
using Logging.Data29;
using Logging.Validators359;
using Portal.Client;
using Portal.Contracts;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;

namespace DataAccess.Handlers
{
    public interface IDataAccess_Handlers_Provider
    {
        /// <summary>Processes the DataAccess_Handlers_Provider operation.</summary>
        void ProcessDataAccess_Handlers_Provider();

        /// <summary>Validates the DataAccess_Handlers_Provider state.</summary>
        bool ValidateDataAccess_Handlers_Provider();
    }

}