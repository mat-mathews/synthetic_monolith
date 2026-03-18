using Auth.Processors400;
using BatchJobs.Models329;
using Billing.Api9;
using GalaxyWorks.Processors;
using Imaging.Client331;
using Imaging.Mappers;
using Import.Service265;
using Import.Validators;
using Logging.Client405;
using Portal.Validators125;
using Portal.Validators69;
using Reporting.Service207;
using Scheduling.Data54;
using Security.Core274;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;

namespace Workflow.Api
{
    public struct Workflow_Api_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}