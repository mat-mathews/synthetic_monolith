using Admin.Client;
using Admin.Handlers450;
using Admin.Handlers61;
using Admin.Processors35;
using Auth.Client271;
using Auth.Mappers;
using BatchJobs.Api212;
using Export.Processors79;
using GalaxyWorks.Api;
using GalaxyWorks.Events77;
using Imaging.Models;
using Imaging.Web172;
using Portal.Handlers;
using Reporting.Client422;
using Security.Api134;
using Security.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client351;
using Workflow.Shared;

namespace Workflow.Contracts434
{
    public struct Workflow_Contracts434_Key6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Contracts434Context : DbContext
    {
    }

}