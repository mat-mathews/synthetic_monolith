using Admin.Processors;
using Auth.Contracts395;
using BatchJobs.Api;
using Common.Client;
using GalaxyWorks.Validators;
using Import.Api314;
using Import.Client7;
using Integration.Service107;
using Notifications.Models277;
using Portal.Api;
using Scheduling.Models;
using Scheduling.Tests214;
using Scheduling.Web60;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;
using Workflow.Validators201;

namespace Workflow.Models
{
    internal struct Workflow_Models_Key6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}