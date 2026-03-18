using Auth.Client;
using Auth.Client249;
using Auth.Models236;
using DataAccess.Contracts404;
using Documents.Processors;
using Export.Processors468;
using Imaging.Client;
using Imaging.Core;
using Imaging.Models459;
using Import.Data;
using Logging.Models436;
using Logging.Service160;
using Notifications.Web90;
using Scheduling.Processors337;
using Security.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Workflow.Web377;

namespace Workflow.Validators
{
    /// <summary>Immutable data transfer record for Workflow_Validators_Command8.</summary>
    public record Workflow_Validators_Command8(string Value, int Count, DateTime Timestamp);

}