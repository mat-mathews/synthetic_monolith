using Admin.Data465;
using Admin.Mappers324;
using Auth.Api;
using Auth.Mappers;
using Auth.Mappers178;
using Billing.Validators;
using Export.Contracts;
using GalaxyWorks.Client;
using Import.Api;
using Import.Client65;
using Integration.Handlers17;
using Notifications.Tests;
using Notifications.Web308;
using Scheduling.Data54;
using Scheduling.Web221;
using Security.Mappers313;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;

namespace Portal.Api51
{
    public struct Portal_Api51_Result9
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}