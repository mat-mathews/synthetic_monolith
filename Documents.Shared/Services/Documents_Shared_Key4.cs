using Admin.Handlers;
using Admin.Handlers450;
using Admin.Handlers61;
using BatchJobs.Models304;
using Billing.Processors259;
using Billing.Validators;
using Common.Client269;
using DataAccess.Core;
using DataAccess.Handlers482;
using Documents.Mappers;
using Export.Mappers;
using Notifications.Core;
using Reporting.Service207;
using Scheduling.Handlers63;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Workflow.Data340;

namespace Documents.Shared
{
    public struct Documents_Shared_Key4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}