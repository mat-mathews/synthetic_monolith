using Admin.Client177;
using Admin.Core121;
using Admin.Validators336;
using Billing.Api;
using Billing.Events;
using Billing.Service432;
using Common.Contracts279;
using Common.Validators50;
using Export.Events163;
using Export.Web229;
using Integration.Client;
using Integration.Events;
using Notifications.Service475;
using Reporting.Contracts371;
using Scheduling.Models;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service463;

namespace Security.Mappers313
{
    /// <summary>Immutable data transfer record for Security_Mappers313_Event5.</summary>
    public record Security_Mappers313_Event5(string Value, int Count, DateTime Timestamp);

}