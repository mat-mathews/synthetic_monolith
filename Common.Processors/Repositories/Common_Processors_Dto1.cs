using Admin.Data117;
using Admin.Service456;
using Auth.Client;
using Auth.Models23;
using Billing.Models;
using Common.Web488;
using Export.Client13;
using Export.Shared332;
using Export.Web130;
using Import.Events;
using Import.Processors472;
using Logging.Handlers141;
using Notifications.Data348;
using Portal.Core;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Core;
using Workflow.Events327;
using Workflow.Shared;

namespace Common.Processors
{
    /// <summary>Immutable data transfer record for Common_Processors_Dto1.</summary>
    public record Common_Processors_Dto1(string Value, int Count, DateTime Timestamp);

}