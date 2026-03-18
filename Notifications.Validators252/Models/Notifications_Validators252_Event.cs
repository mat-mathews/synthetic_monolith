using Admin.Contracts;
using Admin.Handlers450;
using Admin.Models;
using Auth.Models23;
using Common.Web;
using DataAccess.Api307;
using DataAccess.Data36;
using GalaxyWorks.Data375;
using Integration.Service401;
using Logging.Handlers141;
using Notifications.Handlers;
using Reporting.Api;
using Reporting.Contracts371;
using Reporting.Events483;
using Scheduling.Contracts;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;
using Workflow.Client;

namespace Notifications.Validators252
{
    /// <summary>Immutable data transfer record for Notifications_Validators252_Event.</summary>
    public record Notifications_Validators252_Event(string Value, int Count, DateTime Timestamp);

}