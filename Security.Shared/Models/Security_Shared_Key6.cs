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
    public struct Security_Shared_Key6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}