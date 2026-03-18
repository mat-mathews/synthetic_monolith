using Admin.Client346;
using Admin.Shared310;
using Admin.Validators37;
using Auth.Models23;
using Billing.Api;
using Billing.Shared384;
using Documents.Data419;
using Export.Events276;
using Import.Contracts131;
using Import.Handlers407;
using Notifications.Service;
using Portal.Api;
using Portal.Handlers26;
using Reporting.Handlers347;
using Scheduling.Api185;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client351;

namespace Security.Client349
{
    internal struct Security_Client349_Info6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}