using Admin.Service;
using Billing.Contracts;
using Common.Api186;
using Common.Service;
using DataAccess.Handlers;
using Documents.Core;
using Documents.Mappers;
using Export.Core372;
using Export.Processors449;
using GalaxyWorks.Data224;
using GalaxyWorks.Data375;
using Import.Events;
using Logging.Tests;
using Reporting.Events220;
using Security.Data278;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors440;

namespace Scheduling.Service211
{
    internal struct Scheduling_Service211_Result2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Service211Context : DbContext
    {
    }

}