using Admin.Contracts120;
using Admin.Data465;
using Auth.Tests;
using BatchJobs.Handlers443;
using Billing.Mappers124;
using Common.Core;
using DataAccess.Mappers;
using DataAccess.Shared486;
using DataAccess.Validators88;
using Export.Data344;
using Export.Tests;
using GalaxyWorks.Data224;
using GalaxyWorks.Models219;
using Logging.Mappers;
using Notifications.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers97;

namespace GalaxyWorks.Mappers318
{
    /// <summary>Immutable data transfer record for GalaxyWorks_Mappers318_Dto4.</summary>
    public record GalaxyWorks_Mappers318_Dto4(string Value, int Count, DateTime Timestamp);

}