using Admin.Events306;
using Auth.Data;
using BatchJobs.Models304;
using DataAccess.Mappers;
using GalaxyWorks.Api;
using Integration.Mappers242;
using Portal.Core;
using Reporting.Mappers239;
using Scheduling.Api185;
using Scheduling.Models441;
using Scheduling.Shared;
using Security.Client349;
using Security.Mappers313;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Workflow.Data340;

namespace Common.Events280
{
    public struct Common_Events280_Point11
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Events280Context : DbContext
    {
    }

}