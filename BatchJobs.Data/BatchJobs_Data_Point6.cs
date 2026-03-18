using Auth.Api;
using Auth.Handlers;
using Auth.Mappers208;
using BatchJobs.Models304;
using Billing.Contracts44;
using Billing.Handlers101;
using Common.Events;
using Common.Tests;
using DataAccess.Api307;
using DataAccess.Core;
using DataAccess.Models;
using Export.Data6;
using Notifications.Models466;
using Portal.Api;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;

namespace BatchJobs.Data
{
    internal struct BatchJobs_Data_Point6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}