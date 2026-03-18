using Admin.Handlers;
using Admin.Web;
using BatchJobs.Mappers;
using Billing.Contracts44;
using Billing.Core34;
using Common.Validators430;
using Documents.Core357;
using GalaxyWorks.Web;
using Imaging.Events416;
using Integration.Contracts290;
using Logging.Shared;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Contracts32;
using Workflow.Handlers421;
using Workflow.Web;

namespace DataAccess.Validators88
{
    internal struct DataAccess_Validators88_Range2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}