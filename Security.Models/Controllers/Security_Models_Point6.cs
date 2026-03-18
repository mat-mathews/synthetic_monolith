using Admin.Handlers447;
using Admin.Models476;
using Admin.Service339;
using Admin.Validators37;
using Admin.Web46;
using Auth.Events;
using Auth.Mappers206;
using Auth.Processors;
using BatchJobs.Mappers31;
using Billing.Core191;
using Documents.Contracts;
using Export.Processors361;
using Integration.Tests45;
using Notifications.Models277;
using Notifications.Web308;
using Reporting.Handlers;
using Scheduling.Client187;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers370;

namespace Security.Models
{
    public struct Security_Models_Point6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}