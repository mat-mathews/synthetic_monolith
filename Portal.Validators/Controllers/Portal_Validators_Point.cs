using Admin.Client177;
using Admin.Shared363;
using Auth.Client38;
using Auth.Contracts402;
using Common.Core417;
using DataAccess.Contracts;
using Documents.Api156;
using Export.Processors449;
using Export.Tests;
using GalaxyWorks.Data375;
using Imaging.Api127;
using Imaging.Mappers93;
using Logging.Validators359;
using Portal.Events;
using Reporting.Validators;
using Scheduling.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Validators
{
    internal struct Portal_Validators_Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}