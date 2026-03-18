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
    /// <summary>Immutable data transfer record for Imaging_Events_Command11.</summary>
    public record Imaging_Events_Command11(string Value, int Count, DateTime Timestamp);

    public class EventsContext : DbContext
    {
    }

}