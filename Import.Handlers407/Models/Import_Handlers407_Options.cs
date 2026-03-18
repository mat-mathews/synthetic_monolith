using Admin.Web46;
using Auth.Validators;
using Billing.Shared149;
using DataAccess.Client;
using Documents.Api;
using Documents.Service;
using Export.Service30;
using GalaxyWorks.Processors;
using Import.Processors;
using Logging.Models379;
using Logging.Tests;
using Portal.Events139;
using Scheduling.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Processors;
using Workflow.Api;

namespace Import.Handlers407
{
    public struct Import_Handlers407_Options
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}