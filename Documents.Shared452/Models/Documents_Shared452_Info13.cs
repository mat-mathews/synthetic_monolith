using Admin.Contracts120;
using Admin.Shared310;
using BatchJobs.Mappers362;
using Billing.Client;
using DataAccess.Validators;
using Documents.Api129;
using Export.Api49;
using Export.Processors79;
using Export.Validators152;
using Import.Client;
using Logging.Handlers285;
using Logging.Models379;
using Portal.Events151;
using Security.Client349;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests27;

namespace Documents.Shared452
{
    internal struct Documents_Shared452_Info13
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}