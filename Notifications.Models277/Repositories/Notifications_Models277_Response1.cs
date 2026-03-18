using Admin.Validators240;
using Auth.Contracts;
using Auth.Models236;
using Billing.Core191;
using Export.Core372;
using Imaging.Events303;
using Imaging.Models459;
using Import.Contracts;
using Import.Core;
using Integration.Shared;
using Notifications.Service;
using Portal.Validators69;
using Reporting.Api;
using Reporting.Models;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators201;

namespace Notifications.Models277
{
    /// <summary>Immutable data transfer record for Notifications_Models277_Response1.</summary>
    internal record Notifications_Models277_Response1(string Value, int Count, DateTime Timestamp);

}