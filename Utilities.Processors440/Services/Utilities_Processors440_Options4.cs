using Admin.Data408;
using Admin.Validators240;
using BatchJobs.Mappers;
using Billing.Validators174;
using DataAccess.Client;
using Import.Contracts180;
using Integration.Service477;
using Logging.Events289;
using Notifications.Models466;
using Portal.Events139;
using Reporting.Processors;
using Reporting.Processors495;
using Scheduling.Processors335;
using Scheduling.Tests76;
using Security.Processors246;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Processors440
{
    public struct Utilities_Processors440_Options4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}