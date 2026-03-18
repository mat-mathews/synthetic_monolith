using Auth.Api;
using Auth.Events78;
using Auth.Handlers;
using DataAccess.Client82;
using DataAccess.Models;
using GalaxyWorks.Core;
using GalaxyWorks.Core309;
using Imaging.Tests;
using Import.Handlers167;
using Import.Tests;
using Logging.Api;
using Logging.Validators359;
using Portal.Tests;
using Reporting.Events483;
using Security.Core274;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;
using Workflow.Mappers370;

namespace Logging.Web
{
    internal struct Logging_Web_Result6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}