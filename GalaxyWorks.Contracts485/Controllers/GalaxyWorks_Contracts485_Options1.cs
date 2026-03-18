using Admin.Mappers;
using Admin.Web154;
using Auth.Handlers281;
using BatchJobs.Core;
using GalaxyWorks.Contracts;
using Imaging.Shared322;
using Import.Contracts296;
using Import.Processors412;
using Logging.Contracts74;
using Logging.Events;
using Logging.Models436;
using Scheduling.Shared;
using Security.Tests;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service358;
using Workflow.Processors;

namespace GalaxyWorks.Contracts485
{
    public struct GalaxyWorks_Contracts485_Options1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}