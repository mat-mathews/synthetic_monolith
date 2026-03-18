using Admin.Core121;
using Admin.Handlers447;
using Admin.Web4;
using BatchJobs.Api;
using BatchJobs.Contracts399;
using Common.Api213;
using Common.Validators;
using DataAccess.Service464;
using Export.Mappers;
using Export.Shared332;
using GalaxyWorks.Handlers84;
using Import.Events374;
using Integration.Processors248;
using Scheduling.Api185;
using Scheduling.Mappers442;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests27;

namespace Import.Events
{
    internal struct Import_Events_Range8
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}