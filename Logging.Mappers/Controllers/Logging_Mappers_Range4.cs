using Admin.Data465;
using Admin.Processors;
using BatchJobs.Contracts;
using BatchJobs.Events;
using BatchJobs.Tests270;
using Billing.Mappers124;
using DataAccess.Api294;
using Documents.Service;
using Export.Core168;
using Export.Processors;
using Import.Data193;
using Import.Web;
using Reporting.Web345;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;
using Utilities.Contracts;

namespace Logging.Mappers
{
    internal struct Logging_Mappers_Range4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}