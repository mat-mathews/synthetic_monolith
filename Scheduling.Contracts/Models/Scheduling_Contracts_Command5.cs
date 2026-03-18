using Admin.Validators;
using Auth.Models236;
using BatchJobs.Mappers31;
using Billing.Service432;
using DataAccess.Contracts203;
using DataAccess.Web200;
using Imaging.Web172;
using Integration.Contracts;
using Notifications.Contracts;
using Portal.Events139;
using Scheduling.Web264;
using Security.Client349;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Utilities.Web40;
using Workflow.Validators;

namespace Scheduling.Contracts
{
    /// <summary>Immutable data transfer record for Scheduling_Contracts_Command5.</summary>
    internal record Scheduling_Contracts_Command5(string Value, int Count, DateTime Timestamp);

}