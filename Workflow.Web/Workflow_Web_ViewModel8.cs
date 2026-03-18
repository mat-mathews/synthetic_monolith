using Admin.Client346;
using Admin.Service364;
using Admin.Validators;
using Auth.Handlers209;
using Billing.Validators174;
using Documents.Client58;
using Documents.Core357;
using Export.Events276;
using Export.Tests62;
using Imaging.Contracts;
using Integration.Service401;
using Logging.Api;
using Logging.Client;
using Notifications.Contracts;
using Notifications.Models277;
using Reporting.Service207;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Web
{
    /// <summary>Immutable data transfer record for Workflow_Web_ViewModel8.</summary>
    public record Workflow_Web_ViewModel8(string Value, int Count, DateTime Timestamp);

}