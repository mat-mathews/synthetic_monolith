using Admin.Api;
using Admin.Events;
using Auth.Api143;
using Billing.Contracts;
using Billing.Processors259;
using Common.Client;
using Documents.Core357;
using Export.Api49;
using GalaxyWorks.Validators;
using Import.Data;
using Logging.Web;
using Portal.Api;
using Portal.Api99;
using Portal.Tests173;
using Portal.Validators250;
using Scheduling.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers370;

namespace Billing.Service432
{
    /// <summary>Immutable data transfer record for Billing_Service432_Response12.</summary>
    public record Billing_Service432_Response12(string Value, int Count, DateTime Timestamp);

}