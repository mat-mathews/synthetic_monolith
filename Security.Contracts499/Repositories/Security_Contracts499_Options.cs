using Admin.Data408;
using Admin.Events306;
using Admin.Tests10;
using Auth.Processors400;
using Billing.Handlers101;
using Billing.Mappers198;
using DataAccess.Events283;
using Export.Processors111;
using Export.Web210;
using Integration.Client;
using Integration.Service401;
using Logging.Contracts74;
using Logging.Handlers285;
using Notifications.Tests;
using Reporting.Service207;
using Scheduling.Handlers;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators138;

namespace Security.Contracts499
{
    public struct Security_Contracts499_Options
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Contracts499Context : DbContext
    {
    }

}