using Admin.Contracts;
using Admin.Handlers447;
using Auth.Mappers178;
using BatchJobs.Client109;
using Billing.Contracts44;
using Common.Client269;
using Common.Client53;
using Export.Models;
using Integration.Processors248;
using Integration.Service107;
using Notifications.Web;
using Portal.Validators69;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Web398;
using Workflow.Tests222;

namespace Export.Models461
{
    public struct Export_Models461_Options2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}