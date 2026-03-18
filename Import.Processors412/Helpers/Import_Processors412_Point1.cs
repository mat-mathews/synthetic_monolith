using Admin.Data408;
using Admin.Shared363;
using Admin.Tests;
using Auth.Tests498;
using BatchJobs.Mappers;
using Billing.Client73;
using Billing.Shared149;
using Common.Web488;
using Integration.Tests45;
using Logging.Service;
using Notifications.Shared380;
using Portal.Client;
using Portal.Core;
using Reporting.Validators;
using Security.Contracts238;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;
using Workflow.Shared;
using Workflow.Validators201;

namespace Import.Processors412
{
    internal struct Import_Processors412_Point1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}