using Admin.Contracts;
using Admin.Core;
using Admin.Validators37;
using Admin.Web4;
using Auth.Client249;
using Auth.Contracts402;
using BatchJobs.Handlers443;
using Common.Events;
using Documents.Processors;
using Export.Api49;
using GalaxyWorks.Events256;
using GalaxyWorks.Shared;
using Imaging.Tests;
using Import.Tests119;
using Integration.Handlers333;
using Logging.Api;
using Logging.Service;
using Notifications.Models277;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Contracts
{
    /// <summary>Immutable data transfer record for Reporting_Contracts_Dto4.</summary>
    public record Reporting_Contracts_Dto4(string Value, int Count, DateTime Timestamp);

}