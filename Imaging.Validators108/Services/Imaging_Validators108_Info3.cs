using Admin.Events306;
using Admin.Processors35;
using Auth.Mappers206;
using BatchJobs.Processors500;
using BatchJobs.Service;
using Common.Core118;
using Documents.Handlers;
using Export.Client414;
using Export.Validators152;
using Import.Data;
using Logging.Service160;
using Portal.Api99;
using Portal.Service231;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api;
using Workflow.Validators;

namespace Imaging.Validators108
{
    internal struct Imaging_Validators108_Info3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}