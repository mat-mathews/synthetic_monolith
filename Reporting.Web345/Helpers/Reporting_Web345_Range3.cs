using Admin.Client346;
using Admin.Web4;
using BatchJobs.Contracts399;
using Billing.Core;
using DataAccess.Shared;
using Documents.Shared427;
using Export.Api;
using Export.Contracts;
using Logging.Core;
using Notifications.Events42;
using Notifications.Models277;
using Reporting.Mappers239;
using Scheduling.Api;
using Scheduling.Processors335;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;
using Utilities.Validators;

namespace Reporting.Web345
{
    internal struct Reporting_Web345_Range3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}