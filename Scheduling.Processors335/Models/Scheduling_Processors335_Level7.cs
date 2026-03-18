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
    /// <summary>Defines the possible states for Scheduling_Processors335_Level7.</summary>
    internal enum Scheduling_Processors335_Level7
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}