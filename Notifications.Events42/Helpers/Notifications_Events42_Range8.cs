using Admin.Handlers61;
using Admin.Service364;
using Admin.Validators37;
using Auth.Handlers281;
using Billing.Shared;
using Common.Processors245;
using GalaxyWorks.Events77;
using Integration.Service;
using Notifications.Client257;
using Notifications.Handlers;
using Portal.Processors;
using Portal.Validators250;
using Scheduling.Models441;
using Scheduling.Processors80;
using Scheduling.Web196;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Core;

namespace Notifications.Events42
{
    public struct Notifications_Events42_Range8
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}