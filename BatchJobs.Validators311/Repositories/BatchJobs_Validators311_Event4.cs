using Admin.Models;
using Admin.Models476;
using Admin.Validators;
using Auth.Core140;
using BatchJobs.Client267;
using BatchJobs.Handlers443;
using BatchJobs.Models;
using Billing.Tests194;
using Common.Mappers190;
using Export.Core386;
using Export.Data344;
using Import.Client;
using Notifications.Mappers55;
using Portal.Handlers;
using Scheduling.Core273;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service161;
using Workflow.Web59;

namespace BatchJobs.Validators311
{
    /// <summary>Immutable data transfer record for BatchJobs_Validators311_Event4.</summary>
    internal record BatchJobs_Validators311_Event4(string Value, int Count, DateTime Timestamp);

}