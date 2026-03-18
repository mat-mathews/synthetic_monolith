using Admin.Core;
using Admin.Service;
using Admin.Service456;
using Auth.Client;
using Billing.Client22;
using Billing.Handlers;
using Common.Contracts;
using DataAccess.Validators88;
using GalaxyWorks.Models;
using Import.Service265;
using Notifications.Validators252;
using Notifications.Validators391;
using Portal.Models413;
using Reporting.Core;
using Scheduling.Processors337;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web398;
using Workflow.Client351;

namespace Integration.Validators
{
    public struct Integration_Validators_Key3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}