using Admin.Events235;
using Auth.Data;
using Auth.Validators;
using BatchJobs.Api501;
using Billing.Processors103;
using DataAccess.Client;
using DataAccess.Events283;
using Export.Tests;
using Import.Handlers167;
using Logging.Contracts;
using Notifications.Events42;
using Notifications.Validators391;
using Scheduling.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;
using Utilities.Mappers;
using Utilities.Processors91;
using Workflow.Tests27;

namespace DataAccess.Api341
{
    internal struct DataAccess_Api341_Result1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}