using Admin.Handlers;
using Auth.Client38;
using Auth.Data;
using Auth.Handlers281;
using Auth.Models236;
using BatchJobs.Processors;
using Billing.Validators305;
using Common.Handlers;
using Documents.Processors133;
using Documents.Processors300;
using Export.Handlers202;
using Export.Processors449;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Shared437;
using GalaxyWorks.Validators355;
using Imaging.Shared;
using Import.Handlers354;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Contracts371
{
    internal struct Reporting_Contracts371_Options12
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}