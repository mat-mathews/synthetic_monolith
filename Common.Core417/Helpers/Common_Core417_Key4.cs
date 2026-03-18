using Admin.Handlers450;
using Admin.Processors;
using Auth.Processors411;
using BatchJobs.Shared;
using Billing.Processors;
using Billing.Validators174;
using Common.Web;
using Export.Data344;
using Integration.Handlers423;
using Logging.Models436;
using Notifications.Validators252;
using Reporting.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Client;
using Utilities.Processors;
using Utilities.Shared114;
using Workflow.Service161;
using Workflow.Tests222;

namespace Common.Core417
{
    public struct Common_Core417_Key4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Core417Context : DbContext
    {
    }

}