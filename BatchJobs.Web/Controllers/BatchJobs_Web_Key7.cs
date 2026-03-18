using Admin.Api255;
using Admin.Handlers447;
using Admin.Handlers61;
using Admin.Web;
using Billing.Data;
using Billing.Mappers124;
using Billing.Tests194;
using Common.Web438;
using Export.Events;
using GalaxyWorks.Core;
using GalaxyWorks.Service293;
using Imaging.Core204;
using Imaging.Mappers93;
using Portal.Validators125;
using Reporting.Core;
using Reporting.Events317;
using Security.Api320;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchJobs.Web
{
    public struct BatchJobs_Web_Key7
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}