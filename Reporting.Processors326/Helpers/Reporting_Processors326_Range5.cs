using Admin.Handlers450;
using Admin.Handlers61;
using Admin.Processors;
using Admin.Tests10;
using Billing.Handlers122;
using Billing.Validators174;
using Documents.Api156;
using Export.Tests62;
using GalaxyWorks.Handlers385;
using Imaging.Client261;
using Imaging.Service;
using Import.Handlers354;
using Import.Processors;
using Integration.Service477;
using Portal.Contracts;
using Portal.Models;
using Reporting.Data;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Processors326
{
    internal struct Reporting_Processors326_Range5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Processors326Context : DbContext
    {
    }

}