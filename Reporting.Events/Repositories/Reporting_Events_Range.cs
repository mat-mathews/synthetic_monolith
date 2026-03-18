using Admin.Core;
using Admin.Models;
using Admin.Shared14;
using Auth.Api116;
using Auth.Client249;
using DataAccess.Shared189;
using Export.Client13;
using GalaxyWorks.Data224;
using Notifications.Tests;
using Notifications.Web;
using Reporting.Shared;
using Reporting.Tests226;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Utilities.Shared;
using Workflow.Client351;
using Workflow.Web377;

namespace Reporting.Events
{
    public struct Reporting_Events_Range
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}