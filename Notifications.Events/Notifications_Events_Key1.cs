using Auth.Handlers209;
using Auth.Handlers467;
using Billing.Shared312;
using Common.Api213;
using Common.Contracts279;
using Common.Events;
using Export.Models;
using Import.Client7;
using Import.Handlers;
using Integration.Processors241;
using Notifications.Service;
using Portal.Contracts170;
using Reporting.Handlers347;
using Scheduling.Models260;
using Scheduling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests;

namespace Notifications.Events
{
    internal struct Notifications_Events_Key1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}