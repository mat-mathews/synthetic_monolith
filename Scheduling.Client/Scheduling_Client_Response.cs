using Admin.Models;
using Admin.Processors;
using Admin.Tests10;
using Auth.Handlers;
using Auth.Mappers;
using DataAccess.Web;
using Documents.Shared427;
using Export.Mappers;
using Export.Processors;
using Import.Events374;
using Import.Processors472;
using Import.Service291;
using Logging.Client;
using Portal.Tests173;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers197;
using Workflow.Models;
using Workflow.Tests75;

namespace Scheduling.Client
{
    /// <summary>Immutable data transfer record for Scheduling_Client_Response.</summary>
    public record Scheduling_Client_Response(string Value, int Count, DateTime Timestamp);

}