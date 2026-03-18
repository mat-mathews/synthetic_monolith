using Admin.Contracts;
using Admin.Validators431;
using Auth.Data135;
using BatchJobs.Models329;
using Documents.Api251;
using Documents.Shared427;
using Export.Service;
using GalaxyWorks.Processors;
using Import.Mappers;
using Logging.Contracts373;
using Notifications.Web90;
using Portal.Core8;
using Portal.Data216;
using Reporting.Events220;
using Scheduling.Api3;
using Security.Client137;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Tests;
using Workflow.Api433;

namespace GalaxyWorks.Events
{
    public struct GalaxyWorks_Events_Range1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}