using Auth.Handlers;
using Auth.Handlers467;
using Auth.Models236;
using Auth.Shared;
using Billing.Mappers124;
using Common.Web438;
using Export.Events;
using Imaging.Validators;
using Integration.Events;
using Portal.Shared;
using Reporting.Web345;
using Scheduling.Models260;
using Security.Data278;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;
using Workflow.Contracts192;
using Workflow.Tests75;

namespace Portal.Core8
{
    /// <summary>Immutable data transfer record for Portal_Core8_Response2.</summary>
    internal record Portal_Core8_Response2(string Value, int Count, DateTime Timestamp);

}