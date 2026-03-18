using Admin.Models199;
using Admin.Service247;
using Auth.Processors400;
using BatchJobs.Api212;
using BatchJobs.Client109;
using BatchJobs.Events435;
using Billing.Events;
using Billing.Models;
using Common.Api;
using Common.Api186;
using Export.Models;
using Export.Processors426;
using Import.Data;
using Integration.Events;
using Integration.Tests;
using Logging.Handlers285;
using Reporting.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Tests
{
    internal struct Security_Tests_Result6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}