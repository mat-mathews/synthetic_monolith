using Admin.Events306;
using Auth.Client;
using Auth.Mappers28;
using Auth.Processors400;
using Auth.Validators;
using Billing.Api497;
using Billing.Tests194;
using Common.Data;
using DataAccess.Models;
using Documents.Api251;
using Documents.Data68;
using Export.Core386;
using Export.Data344;
using GalaxyWorks.Data453;
using GalaxyWorks.Models219;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;

namespace Security.Core
{
    internal interface ISecurity_Core_Validator
    {
        /// <summary>Processes the Security_Core_Validator operation.</summary>
        void ProcessSecurity_Core_Validator();

        /// <summary>Validates the Security_Core_Validator state.</summary>
        bool ValidateSecurity_Core_Validator();
    }

    public class CoreContext : DbContext
    {
    }

}