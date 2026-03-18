using Admin.Api;
using Admin.Handlers;
using Auth.Data135;
using Billing.Events;
using Billing.Models;
using Common.Contracts279;
using Documents.Api156;
using Export.Api;
using GalaxyWorks.Data224;
using GalaxyWorks.Processors16;
using Imaging.Client261;
using Import.Contracts180;
using Notifications.Events42;
using Notifications.Service;
using Portal.Events151;
using Portal.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;
using Workflow.Web377;

namespace BatchJobs.Client
{
    public struct BatchJobs_Client_Key6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}