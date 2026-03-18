using Admin.Api;
using Admin.Mappers324;
using Auth.Api;
using Auth.Models23;
using Common.Shared;
using Export.Client13;
using Export.Service;
using Import.Models;
using Import.Shared;
using Portal.Api123;
using Portal.Service489;
using Portal.Tests323;
using Reporting.Mappers239;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;
using Workflow.Mappers;
using Workflow.Shared298;

namespace Security.Processors
{
    /// <summary>Immutable data transfer record for Security_Processors_Response5.</summary>
    public record Security_Processors_Response5(string Value, int Count, DateTime Timestamp);

}