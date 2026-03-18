using Admin.Contracts;
using Admin.Events306;
using Admin.Shared;
using Admin.Validators240;
using Admin.Validators37;
using Auth.Api116;
using Auth.Mappers208;
using BatchJobs.Core;
using Documents.Data;
using GalaxyWorks.Data;
using GalaxyWorks.Tests445;
using Import.Processors;
using Portal.Service489;
using Scheduling.Processors;
using Security.Core274;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;

namespace DataAccess.Processors
{
    public struct DataAccess_Processors_Info3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}