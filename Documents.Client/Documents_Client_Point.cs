using Admin.Contracts;
using Auth.Events5;
using Auth.Handlers467;
using Auth.Web70;
using BatchJobs.Events435;
using Billing.Shared312;
using Documents.Contracts;
using Export.Tests62;
using Import.Data193;
using Reporting.Events188;
using Scheduling.Api185;
using Scheduling.Contracts425;
using Scheduling.Models342;
using Scheduling.Web19;
using Security.Models18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Mappers;
using Utilities.Web398;

namespace Documents.Client
{
    internal struct Documents_Client_Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}