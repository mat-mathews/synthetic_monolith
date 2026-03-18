using Admin.Processors;
using Admin.Shared310;
using Auth.Events78;
using Common.Client;
using DataAccess.Mappers;
using DataAccess.Validators409;
using Export.Models461;
using GalaxyWorks.Shared437;
using Import.Mappers;
using Import.Shared;
using Integration.Api;
using Logging.Service160;
using Portal.Client;
using Portal.Mappers233;
using Scheduling.Events;
using Scheduling.Tests76;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web40;

namespace Workflow.Validators201
{
    /// <summary>Defines the possible states for Workflow_Validators201_Type11.</summary>
    internal enum Workflow_Validators201_Type11
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