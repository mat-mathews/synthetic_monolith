using Admin.Api255;
using Admin.Client;
using Admin.Shared;
using Admin.Web;
using Auth.Api143;
using Billing.Processors103;
using Billing.Shared149;
using Common.Data;
using Documents.Events451;
using Documents.Validators102;
using Import.Validators;
using Portal.Contracts;
using Reporting.Api;
using Scheduling.Api;
using Scheduling.Data54;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Workflow.Models253;

namespace Reporting.Events483
{
    /// <summary>Immutable data transfer record for Reporting_Events483_Dto1.</summary>
    internal record Reporting_Events483_Dto1(string Value, int Count, DateTime Timestamp);

}