using Admin.Api;
using Admin.Events235;
using Admin.Service;
using Auth.Api143;
using Auth.Handlers;
using Auth.Handlers209;
using Billing.Validators;
using Export.Contracts;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Validators355;
using Imaging.Core204;
using Integration.Core;
using Notifications.Validators;
using Scheduling.Data54;
using Scheduling.Processors397;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Documents.Handlers
{
    /// <summary>Immutable data transfer record for Documents_Handlers_Event3.</summary>
    internal record Documents_Handlers_Event3(string Value, int Count, DateTime Timestamp);

}