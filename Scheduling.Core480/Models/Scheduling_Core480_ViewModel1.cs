using Admin.Data465;
using Admin.Service339;
using Admin.Tests;
using Auth.Events;
using DataAccess.Client113;
using Documents.Processors133;
using Export.Api12;
using Export.Processors361;
using Imaging.Tests;
using Logging.Data29;
using Logging.Handlers455;
using Portal.Mappers233;
using Reporting.Contracts;
using Security.Client349;
using Security.Service383;
using Security.Tests;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service;

namespace Scheduling.Core480
{
    /// <summary>Immutable data transfer record for Scheduling_Core480_ViewModel1.</summary>
    internal record Scheduling_Core480_ViewModel1(string Value, int Count, DateTime Timestamp);

}