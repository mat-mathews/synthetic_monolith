using Admin.Service247;
using Admin.Validators240;
using Auth.Data135;
using Auth.Processors319;
using BatchJobs.Handlers;
using Billing.Service302;
using Billing.Tests194;
using Export.Client13;
using Integration.Tests92;
using Logging.Contracts74;
using Portal.Api51;
using Portal.Handlers;
using Reporting.Client146;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Utilities.Shared114;
using Workflow.Client;
using Workflow.Contracts434;

namespace Imaging.Shared
{
    /// <summary>Immutable data transfer record for Imaging_Shared_ViewModel.</summary>
    internal record Imaging_Shared_ViewModel(string Value, int Count, DateTime Timestamp);

}