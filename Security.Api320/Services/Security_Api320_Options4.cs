using Admin.Models476;
using BatchJobs.Events435;
using DataAccess.Client113;
using DataAccess.Events283;
using DataAccess.Tests;
using DataAccess.Validators88;
using Documents.Validators102;
using Documents.Web164;
using Export.Core;
using Import.Mappers56;
using Logging.Contracts;
using Logging.Data29;
using Notifications.Shared380;
using Scheduling.Tests76;
using Security.Api;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Api320
{
    internal struct Security_Api320_Options4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}