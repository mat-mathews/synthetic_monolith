using Admin.Events306;
using Admin.Mappers324;
using Admin.Validators240;
using Auth.Core2;
using Auth.Mappers206;
using Documents.Api156;
using Documents.Mappers;
using Documents.Shared427;
using Portal.Api123;
using Portal.Core8;
using Portal.Models;
using Reporting.Api287;
using Scheduling.Tests76;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts228;
using Workflow.Contracts;
using Workflow.Handlers;
using Workflow.Shared298;

namespace Billing.Events
{
    internal struct Billing_Events_Options4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}