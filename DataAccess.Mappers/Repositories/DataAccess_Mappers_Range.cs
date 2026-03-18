using Admin.Core121;
using Admin.Data408;
using Admin.Validators431;
using Auth.Models23;
using Billing.Core34;
using Common.Api57;
using DataAccess.Data36;
using DataAccess.Models;
using Documents.Processors;
using Export.Tests62;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Models219;
using Imaging.Models184;
using Imaging.Web;
using Logging.Processors;
using Scheduling.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public struct DataAccess_Mappers_Range
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}