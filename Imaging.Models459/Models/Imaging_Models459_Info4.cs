using Admin.Models199;
using Admin.Models476;
using Admin.Validators37;
using Auth.Handlers;
using Auth.Mappers206;
using Billing.Core;
using Billing.Handlers101;
using Common.Core118;
using Common.Service258;
using Documents.Shared334;
using Documents.Shared452;
using GalaxyWorks.Processors;
using Import.Client;
using Import.Models457;
using Portal.Api51;
using Scheduling.Mappers48;
using Scheduling.Tests76;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Models459
{
    public struct Imaging_Models459_Info4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Models459Context : DbContext
    {
    }

}