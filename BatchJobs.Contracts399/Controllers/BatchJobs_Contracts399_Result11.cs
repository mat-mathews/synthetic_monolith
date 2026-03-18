using Admin.Contracts;
using Admin.Data;
using Admin.Service339;
using Admin.Service364;
using Admin.Tests10;
using Auth.Mappers28;
using Billing.Api;
using Billing.Handlers101;
using DataAccess.Client82;
using DataAccess.Data;
using Export.Web229;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Handlers478;
using Logging.Events289;
using Notifications.Models;
using Scheduling.Handlers63;
using Scheduling.Processors335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchJobs.Contracts399
{
    internal struct BatchJobs_Contracts399_Result11
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}