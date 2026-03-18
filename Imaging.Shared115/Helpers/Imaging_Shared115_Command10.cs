using Admin.Events235;
using Admin.Shared;
using Auth.Mappers28;
using Auth.Shared;
using Billing.Service;
using Common.Mappers;
using Common.Processors142;
using Common.Service;
using DataAccess.Client113;
using Documents.Shared487;
using Export.Events163;
using Export.Processors;
using Imaging.Events424;
using Import.Data;
using Logging.Service382;
using Scheduling.Processors397;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Shared115
{
    /// <summary>Immutable data transfer record for Imaging_Shared115_Command10.</summary>
    public record Imaging_Shared115_Command10(string Value, int Count, DateTime Timestamp);

}