using Admin.Handlers447;
using Admin.Service247;
using Auth.Api143;
using Auth.Mappers28;
using Billing.Service432;
using Common.Data21;
using DataAccess.Shared486;
using Documents.Shared452;
using Documents.Validators;
using Import.Events;
using Notifications.Processors;
using Portal.Mappers;
using Reporting.Data;
using Scheduling.Web;
using Security.Core274;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Export.Core168
{
    internal struct Export_Core168_Info3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}