using Admin.Contracts;
using Auth.Client38;
using Auth.Handlers467;
using Auth.Mappers;
using Auth.Models23;
using Auth.Processors411;
using Billing.Core191;
using DataAccess.Tests;
using Export.Validators152;
using GalaxyWorks.Api390;
using Import.Handlers;
using Integration.Web;
using Reporting.Service207;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;
using Workflow.Validators201;
using Workflow.Web59;

namespace Notifications.Web
{
    /// <summary>Immutable data transfer record for Notifications_Web_Event3.</summary>
    public record Notifications_Web_Event3(string Value, int Count, DateTime Timestamp);

}