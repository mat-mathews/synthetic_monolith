using Admin.Models199;
using Admin.Service456;
using Admin.Validators431;
using Auth.Api143;
using Auth.Client38;
using BatchJobs.Data176;
using Billing.Api497;
using DataAccess.Processors;
using Documents.Data;
using Documents.Data68;
using Export.Client;
using Integration.Api;
using Notifications.Events42;
using Reporting.Client422;
using Reporting.Events317;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;

namespace Import.Contracts183
{
    public struct Import_Contracts183_Options2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}