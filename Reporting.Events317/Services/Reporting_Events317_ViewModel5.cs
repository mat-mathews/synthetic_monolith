using Admin.Events235;
using Admin.Processors35;
using Admin.Web4;
using DataAccess.Shared189;
using Export.Processors104;
using GalaxyWorks.Api390;
using Imaging.Mappers93;
using Logging.Models379;
using Logging.Shared315;
using Notifications.Core;
using Portal.Shared;
using Scheduling.Models260;
using Scheduling.Models342;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;
using Workflow.Data;
using Workflow.Tests222;

namespace Reporting.Events317
{
    /// <summary>Immutable data transfer record for Reporting_Events317_ViewModel5.</summary>
    internal record Reporting_Events317_ViewModel5(string Value, int Count, DateTime Timestamp);

}