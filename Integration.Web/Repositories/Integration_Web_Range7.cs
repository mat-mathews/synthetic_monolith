using Admin.Core;
using Auth.Handlers467;
using Auth.Processors319;
using BatchJobs.Web;
using Billing.Processors259;
using Common.Api213;
using Common.Web488;
using Documents.Contracts;
using Export.Client;
using Export.Service30;
using Imaging.Events;
using Import.Client7;
using Integration.Service107;
using Logging.Data29;
using Logging.Service382;
using Reporting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Web
{
    internal struct Integration_Web_Range7
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}