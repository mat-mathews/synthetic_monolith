using Admin.Service247;
using Admin.Web;
using Auth.Api116;
using Billing.Handlers101;
using Common.Models381;
using Documents.Api439;
using Documents.Data419;
using Export.Events163;
using Import.Api;
using Integration.Processors71;
using Logging.Api;
using Logging.Handlers285;
using Notifications.Contracts;
using Reporting.Tests67;
using Scheduling.Web19;
using Security.Data278;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Events
{
    public struct Imaging_Events_Range5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}