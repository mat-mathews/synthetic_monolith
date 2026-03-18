using Admin.Data465;
using Admin.Events235;
using Auth.Client249;
using Auth.Contracts395;
using Auth.Handlers;
using Auth.Processors;
using BatchJobs.Api;
using Common.Data;
using Common.Web488;
using DataAccess.Tests282;
using GalaxyWorks.Processors16;
using Import.Models;
using Logging.Mappers157;
using Logging.Service160;
using Logging.Service382;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;

namespace Notifications.Validators
{
    /// <summary>Defines the possible states for Notifications_Validators_Mode.</summary>
    public enum Notifications_Validators_Mode
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