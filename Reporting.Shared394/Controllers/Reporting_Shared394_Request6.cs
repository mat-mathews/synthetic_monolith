using Admin.Handlers447;
using Admin.Mappers324;
using Admin.Models476;
using Auth.Api143;
using Auth.Client249;
using Common.Api;
using DataAccess.Contracts;
using DataAccess.Data36;
using Documents.Shared452;
using Import.Client65;
using Import.Events374;
using Integration.Events301;
using Logging.Data;
using Notifications.Client;
using Notifications.Data406;
using Notifications.Models466;
using Portal.Contracts181;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Shared394
{
    /// <summary>Immutable data transfer record for Reporting_Shared394_Request6.</summary>
    public record Reporting_Shared394_Request6(string Value, int Count, DateTime Timestamp);

}