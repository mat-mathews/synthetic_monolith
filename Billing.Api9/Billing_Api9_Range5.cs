using Admin.Handlers61;
using Admin.Service;
using Auth.Contracts402;
using Auth.Events;
using Billing.Client491;
using Billing.Processors103;
using Common.Client269;
using DataAccess.Validators88;
using Export.Client13;
using Imaging.Client;
using Import.Processors412;
using Logging.Core159;
using Logging.Events;
using Logging.Service;
using Portal.Events;
using Reporting.Tests67;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Api9
{
    public struct Billing_Api9_Range5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}