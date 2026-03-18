using Admin.Data465;
using Admin.Mappers;
using Billing.Models;
using DataAccess.Contracts;
using Documents.Web164;
using Export.Api;
using Imaging.Shared322;
using Import.Processors412;
using Logging.Data29;
using Notifications.Tests195;
using Portal.Core8;
using Portal.Data216;
using Portal.Shared;
using Reporting.Tests226;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;
using Utilities.Processors;

namespace Scheduling.Web196
{
    /// <summary>Immutable data transfer record for Scheduling_Web196_Response1.</summary>
    internal record Scheduling_Web196_Response1(string Value, int Count, DateTime Timestamp);

}