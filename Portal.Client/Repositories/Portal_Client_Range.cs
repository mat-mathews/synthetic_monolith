using Admin.Handlers;
using Admin.Models;
using Admin.Processors;
using Admin.Web4;
using Auth.Contracts402;
using Auth.Core140;
using Common.Tests;
using Documents.Shared427;
using Export.Processors111;
using Import.Tests119;
using Integration.Validators;
using Logging.Handlers455;
using Logging.Web;
using Notifications.Client257;
using Reporting.Processors326;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models253;
using Workflow.Tests;

namespace Portal.Client
{
    internal struct Portal_Client_Range
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}