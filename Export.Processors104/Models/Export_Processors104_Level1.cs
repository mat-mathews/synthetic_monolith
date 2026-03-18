using Admin.Shared14;
using Admin.Validators37;
using Auth.Client38;
using Auth.Events5;
using BatchJobs.Models329;
using Billing.Validators305;
using Common.Processors245;
using DataAccess.Validators;
using Documents.Shared487;
using Imaging.Client;
using Imaging.Tests328;
using Import.Handlers354;
using Integration.Events;
using Notifications.Validators252;
using Portal.Api;
using Reporting.Mappers239;
using Scheduling.Contracts425;
using Scheduling.Models441;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Processors104
{
    /// <summary>Defines the possible states for Export_Processors104_Level1.</summary>
    public enum Export_Processors104_Level1
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}