using Admin.Data465;
using Admin.Models199;
using Auth.Client249;
using Auth.Processors319;
using BatchJobs.Core11;
using Billing.Client182;
using Common.Data81;
using Documents.Data484;
using Documents.Events451;
using Documents.Models;
using Export.Processors361;
using GalaxyWorks.Contracts94;
using Imaging.Events416;
using Import.Web;
using Notifications.Mappers55;
using Notifications.Models277;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Service
{
    internal struct Notifications_Service_Result6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}