using Admin.Handlers447;
using Admin.Processors;
using Admin.Shared363;
using Admin.Validators;
using Auth.Events;
using BatchJobs.Validators;
using Common.Mappers;
using Common.Processors245;
using DataAccess.Api294;
using DataAccess.Api454;
using GalaxyWorks.Service;
using Import.Contracts131;
using Integration.Client;
using Notifications.Service165;
using Notifications.Shared396;
using Portal.Processors389;
using Security.Data;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Core
{
    public struct Billing_Core_Range5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}