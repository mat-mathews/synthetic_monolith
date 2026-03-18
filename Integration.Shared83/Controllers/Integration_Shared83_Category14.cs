using Admin.Api;
using Admin.Client;
using Admin.Client177;
using Admin.Models199;
using Auth.Api;
using Auth.Models23;
using Export.Processors426;
using Imaging.Contracts;
using Import.Handlers;
using Import.Models;
using Integration.Api469;
using Integration.Processors241;
using Logging.Shared;
using Notifications.Client257;
using Portal.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers462;
using Workflow.Contracts192;
using Workflow.Data340;

namespace Integration.Shared83
{
    /// <summary>Defines the possible states for Integration_Shared83_Category14.</summary>
    public enum Integration_Shared83_Category14
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