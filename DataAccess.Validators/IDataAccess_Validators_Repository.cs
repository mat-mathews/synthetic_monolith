using Admin.Api255;
using Admin.Handlers447;
using Admin.Mappers324;
using Auth.Core;
using Auth.Data135;
using Billing.Core191;
using Billing.Mappers124;
using Common.Api;
using Common.Contracts;
using Common.Mappers190;
using DataAccess.Events283;
using DataAccess.Validators88;
using Export.Models262;
using Notifications.Validators252;
using Portal.Core8;
using Reporting.Web105;
using Scheduling.Core273;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Validators
{
    public interface IDataAccess_Validators_Repository
    {
        /// <summary>Processes the DataAccess_Validators_Repository operation.</summary>
        void ProcessDataAccess_Validators_Repository();

        /// <summary>Validates the DataAccess_Validators_Repository state.</summary>
        bool ValidateDataAccess_Validators_Repository();
    }

    public class ValidatorsContext : DbContext
    {
    }

}