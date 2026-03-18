using Admin.Client346;
using Admin.Processors35;
using Admin.Service;
using Admin.Shared;
using Auth.Api143;
using Auth.Client249;
using BatchJobs.Mappers362;
using Billing.Client182;
using Billing.Processors388;
using Common.Api57;
using DataAccess.Validators409;
using Import.Service265;
using Integration.Mappers;
using Portal.Shared;
using Reporting.Events;
using Scheduling.Client187;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared;

namespace Logging.Client
{
    internal struct Logging_Client_Range6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}