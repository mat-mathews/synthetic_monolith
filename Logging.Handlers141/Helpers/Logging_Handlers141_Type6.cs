using Admin.Service339;
using Auth.Client271;
using Auth.Processors;
using Auth.Validators87;
using Common.Handlers;
using DataAccess.Api307;
using DataAccess.Models;
using Documents.Data;
using Imaging.Data;
using Notifications.Validators252;
using Portal.Tests173;
using Reporting.Validators;
using Scheduling.Api185;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;
using Workflow.Mappers;
using Workflow.Models253;

namespace Logging.Handlers141
{
    /// <summary>Defines the possible states for Logging_Handlers141_Type6.</summary>
    public enum Logging_Handlers141_Type6
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