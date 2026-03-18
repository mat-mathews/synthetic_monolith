using Admin.Validators;
using Auth.Api;
using Auth.Api116;
using Auth.Events;
using Auth.Models236;
using Auth.Tests;
using BatchJobs.Shared;
using Common.Shared95;
using Documents.Client;
using Export.Models;
using Export.Processors426;
using Import.Service496;
using Logging.Tests292;
using Portal.Data216;
using Reporting.Processors326;
using Reporting.Web;
using Scheduling.Mappers48;
using Scheduling.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Contracts72
{
    /// <summary>Immutable data transfer record for Security_Contracts72_Response4.</summary>
    public record Security_Contracts72_Response4(string Value, int Count, DateTime Timestamp);

}