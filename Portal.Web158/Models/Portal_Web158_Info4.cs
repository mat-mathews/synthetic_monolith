using Admin.Service;
using Admin.Tests10;
using BatchJobs.Handlers443;
using Billing.Core;
using Billing.Data;
using Billing.Events;
using Common.Api;
using DataAccess.Shared;
using Documents.Processors300;
using Imaging.Processors;
using Notifications.Shared396;
using Portal.Client;
using Reporting.Api287;
using Reporting.Contracts;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Workflow.Client;

namespace Portal.Web158
{
    internal struct Portal_Web158_Info4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}