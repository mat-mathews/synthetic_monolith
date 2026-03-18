using Admin.Handlers;
using Auth.Api116;
using Auth.Core;
using BatchJobs.Processors410;
using Common.Service;
using Export.Events276;
using GalaxyWorks.Data453;
using GalaxyWorks.Events;
using GalaxyWorks.Models219;
using Import.Client356;
using Import.Models;
using Reporting.Processors;
using Reporting.Service207;
using Scheduling.Handlers;
using Scheduling.Handlers43;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests222;

namespace Common.Client
{
    /// <summary>Immutable data transfer record for Common_Client_Dto7.</summary>
    public record Common_Client_Dto7(string Value, int Count, DateTime Timestamp);

}