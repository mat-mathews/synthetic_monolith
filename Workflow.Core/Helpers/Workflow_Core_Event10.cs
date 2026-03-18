using Admin.Handlers450;
using Admin.Processors35;
using Auth.Data;
using BatchJobs.Validators;
using DataAccess.Api;
using DataAccess.Api98;
using Documents.Api129;
using Export.Web479;
using Import.Client7;
using Import.Models457;
using Logging.Service160;
using Scheduling.Processors335;
using Scheduling.Shared39;
using Scheduling.Tests76;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers462;
using Utilities.Models;

namespace Workflow.Core
{
    /// <summary>Immutable data transfer record for Workflow_Core_Event10.</summary>
    public record Workflow_Core_Event10(string Value, int Count, DateTime Timestamp);

    public class CoreContext : DbContext
    {
    }

}