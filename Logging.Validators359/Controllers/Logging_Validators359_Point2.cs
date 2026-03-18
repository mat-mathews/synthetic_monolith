using Admin.Events306;
using Admin.Handlers447;
using Auth.Mappers178;
using Auth.Tests498;
using Billing.Mappers;
using Common.Processors142;
using Export.Core;
using Import.Events;
using Import.Models457;
using Logging.Contracts;
using Notifications.Data406;
using Portal.Tests323;
using Reporting.Web;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service358;
using Workflow.Tests27;
using Workflow.Web;

namespace Logging.Validators359
{
    public struct Logging_Validators359_Point2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}