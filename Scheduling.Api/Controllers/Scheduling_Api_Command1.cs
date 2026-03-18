using Admin.Validators240;
using Auth.Client38;
using Auth.Handlers209;
using Auth.Processors400;
using BatchJobs.Handlers443;
using BatchJobs.Mappers362;
using DataAccess.Contracts404;
using Export.Service205;
using Export.Shared145;
using Imaging.Contracts89;
using Logging.Events;
using Notifications.Contracts;
using Notifications.Tests299;
using Scheduling.Shared39;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Scheduling.Api
{
    /// <summary>Immutable data transfer record for Scheduling_Api_Command1.</summary>
    public record Scheduling_Api_Command1(string Value, int Count, DateTime Timestamp);

    public class ApiContext : DbContext
    {
    }

}