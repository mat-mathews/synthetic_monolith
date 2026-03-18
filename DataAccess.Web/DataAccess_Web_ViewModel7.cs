using Admin.Client;
using Auth.Api116;
using Auth.Core140;
using Auth.Events78;
using BatchJobs.Contracts;
using Common.Web438;
using DataAccess.Validators409;
using Documents.Mappers;
using GalaxyWorks.Data453;
using GalaxyWorks.Mappers;
using Import.Api314;
using Import.Core;
using Import.Mappers;
using Reporting.Events;
using Security.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;

namespace DataAccess.Web
{
    /// <summary>Immutable data transfer record for DataAccess_Web_ViewModel7.</summary>
    internal record DataAccess_Web_ViewModel7(string Value, int Count, DateTime Timestamp);

}