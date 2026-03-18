using Admin.Api255;
using Admin.Handlers;
using Admin.Handlers61;
using Admin.Shared363;
using Auth.Data;
using Billing.Api9;
using Billing.Handlers101;
using Common.Events367;
using Common.Web;
using Documents.Client;
using Import.Processors;
using Integration.Processors71;
using Notifications.Shared;
using Portal.Events139;
using Scheduling.Core;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;

namespace Notifications.Handlers112
{
    internal struct Notifications_Handlers112_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}