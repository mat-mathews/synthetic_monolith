using Admin.Api255;
using Admin.Service;
using Auth.Shared325;
using BatchJobs.Processors500;
using Common.Models381;
using Documents.Shared334;
using Export.Handlers202;
using Imaging.Shared;
using Import.Api272;
using Import.Handlers;
using Notifications.Api144;
using Portal.Shared;
using Scheduling.Models441;
using Security.Api134;
using Security.Client137;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;

namespace Scheduling.Web60
{
    /// <summary>Immutable data transfer record for Scheduling_Web60_Event6.</summary>
    internal record Scheduling_Web60_Event6(string Value, int Count, DateTime Timestamp);

}