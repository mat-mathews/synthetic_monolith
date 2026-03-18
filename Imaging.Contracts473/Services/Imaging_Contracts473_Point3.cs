using Admin.Data117;
using Admin.Events306;
using Admin.Service364;
using Auth.Mappers28;
using Auth.Tests;
using Billing.Client22;
using Billing.Contracts44;
using Billing.Mappers;
using Documents.Data;
using Documents.Data68;
using Export.Service30;
using Export.Web;
using GalaxyWorks.Processors16;
using Logging.Contracts373;
using Notifications.Tests;
using Portal.Tests323;
using Reporting.Api287;
using Scheduling.Processors80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Contracts473
{
    internal struct Imaging_Contracts473_Point3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}