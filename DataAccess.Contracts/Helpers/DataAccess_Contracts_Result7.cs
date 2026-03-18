using Admin.Client177;
using Admin.Mappers;
using Admin.Validators240;
using Auth.Validators87;
using BatchJobs.Core11;
using BatchJobs.Handlers;
using BatchJobs.Mappers;
using Billing.Processors259;
using Documents.Api129;
using GalaxyWorks.Core309;
using Imaging.Validators;
using Integration.Shared83;
using Notifications.Contracts;
using Reporting.Handlers347;
using Reporting.Mappers;
using Security.Client;
using Security.Models136;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public struct DataAccess_Contracts_Result7
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}