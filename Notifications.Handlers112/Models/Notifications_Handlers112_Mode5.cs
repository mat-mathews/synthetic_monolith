using Admin.Api255;
using Admin.Handlers;
using Admin.Handlers61;
using Admin.Shared363;
using Auth.Data;
using Billing.Api9;
using Billing.Handlers101;
using Common.Events367;
using Common.Web;
using Documents.Client;
using Import.Processors;
using Integration.Processors71;
using Notifications.Shared;
using Portal.Events139;
using Scheduling.Core;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;

namespace Notifications.Handlers112
{
    /// <summary>Defines the possible states for Notifications_Handlers112_Mode5.</summary>
    public enum Notifications_Handlers112_Mode5
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