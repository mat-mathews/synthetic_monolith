using Admin.Handlers447;
using Admin.Handlers61;
using Auth.Contracts395;
using Auth.Data135;
using Billing.Contracts44;
using Common.Data;
using Common.Events;
using DataAccess.Mappers;
using Documents.Tests106;
using Export.Service;
using Imaging.Client331;
using Import.Client64;
using Import.Contracts296;
using Logging.Handlers;
using Notifications.Core166;
using Reporting.Api287;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web398;

namespace Logging.Data
{
    /// <summary>Immutable data transfer record for Logging_Data_Response4.</summary>
    internal record Logging_Data_Response4(string Value, int Count, DateTime Timestamp);

}