using Admin.Data465;
using Admin.Handlers447;
using Billing.Client73;
using Billing.Processors;
using DataAccess.Web200;
using Export.Service30;
using GalaxyWorks.Tests445;
using Import.Data;
using Import.Processors412;
using Logging.Client405;
using Portal.Events139;
using Portal.Web494;
using Reporting.Processors326;
using Scheduling.Processors80;
using Security.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;
using Workflow.Client;

namespace Workflow.Mappers
{
    /// <summary>Immutable data transfer record for Workflow_Mappers_Request.</summary>
    public record Workflow_Mappers_Request(string Value, int Count, DateTime Timestamp);

}