using Admin.Data117;
using Admin.Models476;
using Admin.Tests;
using Admin.Validators336;
using Admin.Web4;
using Billing.Contracts;
using Billing.Handlers;
using Documents.Data;
using Export.Processors449;
using GalaxyWorks.Events;
using Imaging.Events303;
using Import.Handlers;
using Logging.Client;
using Reporting.Api287;
using Scheduling.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Workflow.Web59;

namespace Export.Data
{
    /// <summary>Immutable data transfer record for Export_Data_Response3.</summary>
    public record Export_Data_Response3(string Value, int Count, DateTime Timestamp);

}