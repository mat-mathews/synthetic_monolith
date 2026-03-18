using Admin.Core;
using Admin.Handlers;
using Auth.Api143;
using Auth.Mappers206;
using Common.Web;
using DataAccess.Tests;
using Documents.Shared334;
using Export.Events;
using Export.Service205;
using GalaxyWorks.Api390;
using GalaxyWorks.Contracts392;
using Logging.Mappers;
using Reporting.Shared394;
using Scheduling.Data;
using Security.Events288;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Events327;
using Workflow.Validators;

namespace Auth.Web
{
    public struct Auth_Web_Range4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}