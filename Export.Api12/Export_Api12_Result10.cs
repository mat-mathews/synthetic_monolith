using Auth.Client38;
using Export.Models461;
using Export.Service;
using Export.Shared;
using Import.Api314;
using Import.Client7;
using Integration.Api;
using Integration.Handlers333;
using Integration.Tests;
using Logging.Service382;
using Portal.Api123;
using Portal.Handlers26;
using Portal.Shared;
using Reporting.Core;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Export.Api12
{
    public struct Export_Api12_Result10
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}