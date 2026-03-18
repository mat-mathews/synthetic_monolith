using Admin.Service456;
using Admin.Validators431;
using Auth.Service;
using BatchJobs.Core11;
using Billing.Contracts44;
using Documents.Shared334;
using Export.Data6;
using Export.Processors361;
using GalaxyWorks.Data224;
using Integration.Validators369;
using Notifications.Core166;
using Portal.Data266;
using Reporting.Tests226;
using Scheduling.Tests76;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;
using Workflow.Models;
using Workflow.Models253;

namespace Security.Models136
{
    public struct Security_Models136_Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}