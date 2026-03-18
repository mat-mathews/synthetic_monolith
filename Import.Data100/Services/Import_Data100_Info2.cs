using Admin.Handlers;
using Auth.Mappers178;
using BatchJobs.Client109;
using Billing.Mappers198;
using Billing.Mappers225;
using Billing.Tests;
using DataAccess.Service464;
using Documents.Tests;
using Notifications.Client257;
using Notifications.Validators391;
using Scheduling.Processors25;
using Scheduling.Tests;
using Security.Models18;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;
using Workflow.Tests;

namespace Import.Data100
{
    internal struct Import_Data100_Info2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}