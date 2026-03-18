using Admin.Client177;
using Admin.Data465;
using Admin.Shared14;
using Auth.Web;
using Billing.Shared312;
using Documents.Api156;
using Imaging.Events303;
using Integration.Mappers242;
using Notifications.Client;
using Notifications.Events;
using Portal.Api99;
using Portal.Tests;
using Reporting.Api287;
using Reporting.Events220;
using Reporting.Web105;
using Security.Mappers313;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Billing.Mappers198
{
    /// <summary>Immutable data transfer record for Billing_Mappers198_Event.</summary>
    public record Billing_Mappers198_Event(string Value, int Count, DateTime Timestamp);

}