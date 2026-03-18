using Admin.Processors35;
using Auth.Client271;
using Auth.Mappers178;
using BatchJobs.Handlers443;
using Billing.Shared;
using Documents.Data484;
using Export.Models262;
using GalaxyWorks.Core;
using Import.Api;
using Import.Events493;
using Import.Service496;
using Logging.Tests292;
using Notifications.Validators252;
using Portal.Validators;
using Security.Client349;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Workflow.Contracts192;

namespace Scheduling.Validators
{
    /// <summary>Immutable data transfer record for Scheduling_Validators_Dto7.</summary>
    public record Scheduling_Validators_Dto7(string Value, int Count, DateTime Timestamp);

    public class ValidatorsContext : DbContext
    {
    }

}