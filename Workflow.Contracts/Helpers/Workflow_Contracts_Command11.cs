using Admin.Processors35;
using Auth.Events78;
using BatchJobs.Client;
using BatchJobs.Client267;
using BatchJobs.Processors;
using Common.Shared;
using Documents.Core;
using Documents.Handlers;
using Export.Core386;
using GalaxyWorks.Validators355;
using Imaging.Shared115;
using Import.Contracts131;
using Logging.Api316;
using Logging.Models379;
using Portal.Service231;
using Portal.Service378;
using Reporting.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Contracts
{
    /// <summary>Immutable data transfer record for Workflow_Contracts_Command11.</summary>
    internal record Workflow_Contracts_Command11(string Value, int Count, DateTime Timestamp);

}