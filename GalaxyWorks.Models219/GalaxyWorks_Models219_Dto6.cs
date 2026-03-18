using Admin.Models199;
using BatchJobs.Handlers;
using BatchJobs.Validators;
using Billing.Models;
using Common.Data;
using Export.Processors468;
using Export.Tests;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Mappers318;
using Import.Contracts296;
using Logging.Mappers;
using Logging.Validators359;
using Portal.Web494;
using Security.Client137;
using Security.Events288;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;

namespace GalaxyWorks.Models219
{
    /// <summary>Immutable data transfer record for GalaxyWorks_Models219_Dto6.</summary>
    internal record GalaxyWorks_Models219_Dto6(string Value, int Count, DateTime Timestamp);

}