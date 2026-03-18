using Admin.Events;
using Admin.Shared14;
using Auth.Client;
using Auth.Core;
using Auth.Mappers178;
using Auth.Models23;
using Auth.Tests498;
using BatchJobs.Client109;
using BatchJobs.Processors;
using Billing.Api;
using DataAccess.Data;
using Documents.Contracts;
using Export.Client;
using Export.Processors;
using Logging.Contracts74;
using Reporting.Processors326;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Import.Service291
{
    /// <summary>Immutable data transfer record for Import_Service291_Request3.</summary>
    public record Import_Service291_Request3(string Value, int Count, DateTime Timestamp);

}