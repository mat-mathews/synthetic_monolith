using Admin.Shared;
using Admin.Validators;
using BatchJobs.Api501;
using Billing.Events;
using Common.Events280;
using DataAccess.Client;
using DataAccess.Web200;
using Documents.Handlers;
using Documents.Tests171;
using Imaging.Mappers275;
using Imaging.Processors;
using Notifications.Web;
using Reporting.Events317;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Utilities.Mappers97;
using Workflow.Client351;

namespace Common.Mappers
{
    public struct Common_Mappers_Options1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}