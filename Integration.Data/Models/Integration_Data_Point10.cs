using Admin.Shared14;
using Auth.Client38;
using Billing.Client22;
using Billing.Web;
using Documents.Data484;
using Export.Web479;
using GalaxyWorks.Api;
using GalaxyWorks.Events;
using Import.Service;
using Logging.Client;
using Logging.Models379;
using Notifications.Client;
using Portal.Core8;
using Reporting.Api287;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api433;
using Workflow.Service161;
using Workflow.Tests;

namespace Integration.Data
{
    internal struct Integration_Data_Point10
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}