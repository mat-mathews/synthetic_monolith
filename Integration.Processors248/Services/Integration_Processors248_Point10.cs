using Admin.Data;
using Admin.Events;
using Auth.Data;
using BatchJobs.Models329;
using Billing.Client;
using Common.Api186;
using Common.Contracts279;
using Export.Mappers237;
using Imaging.Events;
using Import.Processors472;
using Import.Service265;
using Integration.Tests45;
using Logging.Models;
using Logging.Models436;
using Reporting.Service;
using Reporting.Web345;
using Scheduling.Shared39;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Processors248
{
    public struct Integration_Processors248_Point10
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}