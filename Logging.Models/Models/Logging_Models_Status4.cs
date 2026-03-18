using Admin.Web46;
using Auth.Contracts;
using Auth.Mappers208;
using BatchJobs.Events435;
using Common.Mappers343;
using DataAccess.Contracts203;
using Documents.Events;
using Export.Client;
using Export.Handlers;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Events77;
using Import.Service291;
using Logging.Api316;
using Reporting.Models;
using Scheduling.Contracts;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Models
{
    /// <summary>Defines the possible states for Logging_Models_Status4.</summary>
    public enum Logging_Models_Status4
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