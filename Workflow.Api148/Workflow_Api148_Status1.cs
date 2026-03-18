using Admin.Handlers;
using Admin.Handlers447;
using Admin.Validators37;
using Auth.Client249;
using Auth.Core140;
using Common.Web;
using Documents.Api129;
using Documents.Tests;
using Export.Data6;
using Export.Models262;
using Imaging.Mappers93;
using Import.Core;
using Notifications.Models;
using Reporting.Processors495;
using Reporting.Shared;
using Security.Events288;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;

namespace Workflow.Api148
{
    /// <summary>Defines the possible states for Workflow_Api148_Status1.</summary>
    public enum Workflow_Api148_Status1
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