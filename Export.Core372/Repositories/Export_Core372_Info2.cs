using Auth.Client38;
using Auth.Events78;
using BatchJobs.Handlers;
using Billing.Core191;
using DataAccess.Models;
using Documents.Data68;
using Documents.Validators;
using Logging.Core;
using Notifications.Mappers55;
using Notifications.Shared396;
using Portal.Tests481;
using Portal.Web158;
using Reporting.Processors326;
using Scheduling.Processors;
using Security.Client353;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;
using Workflow.Tests27;

namespace Export.Core372
{
    public struct Export_Core372_Info2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}