using Admin.Client346;
using Admin.Mappers;
using BatchJobs.Models329;
using Common.Processors;
using Common.Validators50;
using DataAccess.Contracts;
using DataAccess.Validators88;
using Documents.Data490;
using Documents.Shared452;
using Export.Handlers202;
using Export.Processors361;
using Export.Shared145;
using Import.Core;
using Integration.Service;
using Scheduling.Tests76;
using Scheduling.Web60;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Events163
{
    internal struct Export_Events163_Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}