using Admin.Handlers450;
using Admin.Shared;
using Auth.Client;
using Auth.Events78;
using Auth.Service;
using Auth.Web70;
using BatchJobs.Api212;
using BatchJobs.Handlers443;
using Billing.Events;
using Common.Shared;
using Common.Shared95;
using Documents.Data492;
using Documents.Events;
using Integration.Processors241;
using Logging.Handlers455;
using Portal.Tests323;
using Scheduling.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests222;

namespace Export.Processors361
{
    public struct Export_Processors361_Options
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}