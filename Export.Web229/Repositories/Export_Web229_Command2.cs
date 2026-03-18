using Auth.Events;
using Auth.Handlers;
using BatchJobs.Client109;
using BatchJobs.Shared;
using Billing.Validators174;
using Import.Data;
using Integration.Handlers333;
using Logging.Api316;
using Portal.Service;
using Reporting.Client146;
using Reporting.Events;
using Reporting.Shared394;
using Reporting.Tests67;
using Reporting.Web;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers370;
using Workflow.Validators;

namespace Export.Web229
{
    /// <summary>Immutable data transfer record for Export_Web229_Command2.</summary>
    public record Export_Web229_Command2(string Value, int Count, DateTime Timestamp);

}