using Admin.Client346;
using Admin.Shared;
using Admin.Shared14;
using Auth.Shared;
using BatchJobs.Processors500;
using Billing.Contracts;
using Common.Events;
using DataAccess.Data36;
using Documents.Web164;
using Export.Processors111;
using Export.Service205;
using Integration.Processors241;
using Notifications.Data;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Workflow.Service463;

namespace Security.Shared
{
    /// <summary>Defines the possible states for Security_Shared_Type10.</summary>
    internal enum Security_Shared_Type10
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