using Admin.Client346;
using Admin.Handlers;
using Auth.Events5;
using BatchJobs.Data176;
using BatchJobs.Validators;
using Billing.Handlers122;
using Common.Client;
using DataAccess.Api98;
using Export.Processors426;
using Export.Service30;
using Integration.Shared83;
using Notifications.Handlers470;
using Portal.Validators69;
using Security.Client137;
using Security.Handlers;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Contracts238
{
    internal struct Security_Contracts238_Options2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}