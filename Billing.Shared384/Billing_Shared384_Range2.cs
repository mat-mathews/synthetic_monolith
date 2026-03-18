using Admin.Data465;
using Admin.Models199;
using Admin.Validators431;
using Auth.Client249;
using BatchJobs.Events;
using Billing.Contracts;
using Billing.Service432;
using Common.Core169;
using Documents.Shared452;
using Export.Core;
using Export.Processors468;
using Export.Web479;
using Imaging.Client;
using Import.Tests;
using Logging.Shared;
using Scheduling.Api;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Billing.Shared384
{
    public struct Billing_Shared384_Range2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}