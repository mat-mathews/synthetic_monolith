using Admin.Data;
using Admin.Events235;
using Admin.Models;
using Admin.Service456;
using Admin.Shared14;
using Auth.Contracts;
using BatchJobs.Validators;
using Documents.Data;
using Export.Data150;
using Imaging.Client261;
using Import.Processors412;
using Integration.Service147;
using Logging.Core159;
using Scheduling.Contracts425;
using Security.Contracts238;
using Security.Processors295;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Workflow.Client
{
    /// <summary>Immutable data transfer record for Workflow_Client_Event4.</summary>
    public record Workflow_Client_Event4(string Value, int Count, DateTime Timestamp);

}