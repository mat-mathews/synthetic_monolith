using Admin.Events;
using Admin.Models;
using Billing.Validators174;
using Billing.Validators305;
using Common.Validators;
using Export.Client;
using Export.Core372;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Validators;
using Integration.Web;
using Notifications.Models277;
using Notifications.Tests;
using Portal.Data216;
using Reporting.Client422;
using Reporting.Data;
using Reporting.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Handlers460
{
    internal struct Security_Handlers460_Info3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Handlers460Context : DbContext
    {
    }

}