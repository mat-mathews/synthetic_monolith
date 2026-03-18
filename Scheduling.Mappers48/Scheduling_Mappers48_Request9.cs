using Admin.Api;
using Auth.Handlers281;
using Auth.Handlers467;
using DataAccess.Validators;
using DataAccess.Web200;
using Documents.Client;
using Documents.Events451;
using Export.Api12;
using Export.Processors104;
using Imaging.Api;
using Imaging.Mappers93;
using Integration.Validators;
using Notifications.Tests;
using Portal.Service489;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;
using Workflow.Data340;

namespace Scheduling.Mappers48
{
    /// <summary>Immutable data transfer record for Scheduling_Mappers48_Request9.</summary>
    public record Scheduling_Mappers48_Request9(string Value, int Count, DateTime Timestamp);

}