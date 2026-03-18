using Admin.Data;
using Admin.Handlers;
using Admin.Mappers;
using Admin.Web;
using BatchJobs.Processors;
using Billing.Handlers101;
using Billing.Handlers122;
using Billing.Mappers124;
using Billing.Validators;
using DataAccess.Api294;
using DataAccess.Api341;
using Documents.Api;
using GalaxyWorks.Data153;
using Import.Contracts;
using Notifications.Mappers;
using Portal.Tests173;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Mappers
{
    internal struct Export_Mappers_Range1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}