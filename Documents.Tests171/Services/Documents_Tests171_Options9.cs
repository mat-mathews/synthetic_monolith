using Admin.Api;
using Admin.Handlers450;
using Admin.Service;
using Auth.Api116;
using Auth.Events5;
using Auth.Models23;
using Billing.Mappers225;
using Common.Data;
using Common.Service258;
using Documents.Models;
using GalaxyWorks.Client;
using Imaging.Api;
using Integration.Client;
using Integration.Processors;
using Logging.Core159;
using Logging.Shared315;
using Portal.Contracts;
using Reporting.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tests171
{
    public struct Documents_Tests171_Options9
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}