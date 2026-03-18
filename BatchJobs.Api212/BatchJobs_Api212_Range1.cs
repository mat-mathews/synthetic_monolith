using Admin.Handlers;
using Admin.Service;
using Auth.Api;
using Auth.Processors400;
using BatchJobs.Events;
using Billing.Tests;
using Documents.Api439;
using Documents.Tests106;
using Export.Web210;
using Import.Models457;
using Import.Service291;
using Integration.Handlers423;
using Logging.Contracts74;
using Notifications.Models466;
using Scheduling.Client;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers97;

namespace BatchJobs.Api212
{
    public struct BatchJobs_Api212_Range1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}