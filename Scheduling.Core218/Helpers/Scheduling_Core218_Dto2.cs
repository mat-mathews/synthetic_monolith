using Admin.Shared;
using Auth.Api143;
using Auth.Validators;
using Billing.Client22;
using Common.Handlers;
using Documents.Tests171;
using Export.Core386;
using GalaxyWorks.Mappers318;
using GalaxyWorks.Validators;
using Logging.Handlers368;
using Portal.Api123;
using Portal.Shared;
using Scheduling.Core480;
using Scheduling.Handlers;
using Scheduling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;
using Workflow.Api;

namespace Scheduling.Core218
{
    /// <summary>Immutable data transfer record for Scheduling_Core218_Dto2.</summary>
    internal record Scheduling_Core218_Dto2(string Value, int Count, DateTime Timestamp);

    public class Core218Context : DbContext
    {
    }

}