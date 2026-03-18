using Admin.Service364;
using Auth.Data;
using Auth.Models23;
using Auth.Shared;
using Auth.Web;
using BatchJobs.Data176;
using BatchJobs.Mappers;
using DataAccess.Tests;
using GalaxyWorks.Tests;
using Import.Handlers407;
using Logging.Validators;
using Portal.Api99;
using Reporting.Shared;
using Reporting.Web105;
using Scheduling.Web19;
using Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data;
using Workflow.Mappers370;

namespace Scheduling.Web
{
    internal struct Scheduling_Web_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}