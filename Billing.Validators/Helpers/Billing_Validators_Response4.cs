using Admin.Shared310;
using Auth.Client271;
using BatchJobs.Models;
using Common.Service258;
using DataAccess.Tests286;
using Documents.Tests;
using GalaxyWorks.Contracts94;
using Imaging.Mappers93;
using Import.Api272;
using Import.Processors472;
using Notifications.Handlers112;
using Notifications.Validators391;
using Portal.Api99;
using Reporting.Web345;
using Scheduling.Contracts;
using Scheduling.Core273;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Validators
{
    /// <summary>Immutable data transfer record for Billing_Validators_Response4.</summary>
    public record Billing_Validators_Response4(string Value, int Count, DateTime Timestamp);

    public class ValidatorsContext : DbContext
    {
    }

}