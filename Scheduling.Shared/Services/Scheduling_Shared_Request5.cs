using Admin.Contracts;
using Admin.Validators;
using Auth.Contracts402;
using Auth.Processors319;
using Common.Events;
using Common.Events280;
using Common.Validators430;
using Documents.Shared452;
using Documents.Tests171;
using Import.Service429;
using Import.Service496;
using Import.Shared;
using Integration.Events;
using Notifications.Data348;
using Portal.Web158;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;
using Workflow.Client;

namespace Scheduling.Shared
{
    /// <summary>Immutable data transfer record for Scheduling_Shared_Request5.</summary>
    public record Scheduling_Shared_Request5(string Value, int Count, DateTime Timestamp);

}