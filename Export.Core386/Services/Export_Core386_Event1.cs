using Admin.Core121;
using Admin.Events;
using Admin.Web4;
using Auth.Events5;
using BatchJobs.Tests270;
using Billing.Core191;
using Common.Data81;
using Export.Processors361;
using GalaxyWorks.Contracts485;
using Integration.Handlers17;
using Logging.Core159;
using Notifications.Handlers33;
using Portal.Service378;
using Security.Models420;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;
using Workflow.Mappers370;

namespace Export.Core386
{
    /// <summary>Immutable data transfer record for Export_Core386_Event1.</summary>
    internal record Export_Core386_Event1(string Value, int Count, DateTime Timestamp);

}