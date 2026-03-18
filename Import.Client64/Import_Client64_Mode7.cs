using Admin.Handlers;
using Admin.Processors;
using Admin.Validators37;
using Admin.Web;
using Billing.Api497;
using Common.Api213;
using DataAccess.Tests;
using DataAccess.Validators88;
using Documents.Validators;
using Documents.Validators102;
using Export.Contracts;
using Integration.Contracts290;
using Integration.Mappers242;
using Notifications.Client;
using Notifications.Data348;
using Notifications.Service165;
using Notifications.Web90;
using Portal.Tests323;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Client64
{
    /// <summary>Defines the possible states for Import_Client64_Mode7.</summary>
    internal enum Import_Client64_Mode7
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