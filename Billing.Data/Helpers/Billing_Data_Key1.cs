using Admin.Processors;
using Admin.Shared310;
using Auth.Client271;
using Auth.Mappers178;
using BatchJobs.Events435;
using BatchJobs.Validators311;
using Export.Shared332;
using GalaxyWorks.Data;
using Import.Contracts131;
using Import.Handlers167;
using Import.Service15;
using Integration.Handlers244;
using Reporting.Client;
using Reporting.Client146;
using Scheduling.Core218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;

namespace Billing.Data
{
    internal struct Billing_Data_Key1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}