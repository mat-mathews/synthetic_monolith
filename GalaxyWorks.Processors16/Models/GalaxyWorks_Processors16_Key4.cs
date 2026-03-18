using Admin.Shared310;
using Auth.Data;
using BatchJobs.Shared;
using Billing.Processors103;
using DataAccess.Events283;
using DataAccess.Validators409;
using Export.Models;
using Export.Models461;
using GalaxyWorks.Validators355;
using Imaging.Contracts89;
using Integration.Contracts290;
using Notifications.Service165;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors440;
using Workflow.Api148;
using Workflow.Service161;
using Workflow.Tests75;

namespace GalaxyWorks.Processors16
{
    public struct GalaxyWorks_Processors16_Key4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}