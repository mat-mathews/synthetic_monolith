using Admin.Data117;
using Admin.Handlers450;
using Admin.Service364;
using Auth.Models23;
using Auth.Processors;
using Billing.Api;
using Billing.Mappers;
using Billing.Tests194;
using Common.Api213;
using Export.Data344;
using GalaxyWorks.Contracts;
using Imaging.Events;
using Import.Events493;
using Portal.Tests173;
using Reporting.Data;
using Scheduling.Tests76;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers197;
using Workflow.Tests222;

namespace Export.Shared145
{
    public struct Export_Shared145_Options
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}