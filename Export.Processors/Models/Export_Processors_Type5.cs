using Admin.Tests10;
using Auth.Contracts;
using Auth.Data;
using BatchJobs.Handlers443;
using Documents.Service;
using Imaging.Events424;
using Import.Handlers;
using Integration.Contracts290;
using Integration.Shared;
using Logging.Contracts373;
using Portal.Api51;
using Scheduling.Models441;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;
using Utilities.Models;
using Workflow.Validators201;

namespace Export.Processors
{
    /// <summary>Defines the possible states for Export_Processors_Type5.</summary>
    internal enum Export_Processors_Type5
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class ProcessorsContext : DbContext
    {
    }

}