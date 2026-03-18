using Admin.Handlers61;
using Admin.Models199;
using Auth.Contracts402;
using Billing.Mappers198;
using Common.Core169;
using Common.Processors245;
using Common.Validators50;
using Export.Data6;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Data375;
using Import.Tests;
using Logging.Validators;
using Scheduling.Processors397;
using Security.Core;
using Security.Models420;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Processors335
{
    internal interface IScheduling_Processors335_Validator10
    {
        /// <summary>Processes the Scheduling_Processors335_Validator10 operation.</summary>
        void ProcessScheduling_Processors335_Validator10();

        /// <summary>Validates the Scheduling_Processors335_Validator10 state.</summary>
        bool ValidateScheduling_Processors335_Validator10();
    }

}