using Admin.Events;
using Admin.Shared310;
using Admin.Web46;
using Auth.Api;
using Auth.Data135;
using Auth.Mappers28;
using Billing.Service432;
using GalaxyWorks.Handlers;
using Imaging.Client;
using Imaging.Tests328;
using Import.Data;
using Logging.Handlers368;
using Portal.Processors389;
using Portal.Service231;
using Portal.Validators;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Events283
{
    internal interface IDataAccess_Events283_Service
    {
        /// <summary>Processes the DataAccess_Events283_Service operation.</summary>
        void ProcessDataAccess_Events283_Service();

        /// <summary>Validates the DataAccess_Events283_Service state.</summary>
        bool ValidateDataAccess_Events283_Service();
    }

}