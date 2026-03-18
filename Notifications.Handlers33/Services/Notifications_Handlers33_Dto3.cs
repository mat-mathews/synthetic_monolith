using Admin.Contracts120;
using Admin.Shared14;
using Admin.Shared310;
using Admin.Shared363;
using Auth.Validators;
using Common.Service;
using DataAccess.Processors;
using Documents.Models;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Data453;
using Imaging.Service;
using Logging.Handlers285;
using Notifications.Models;
using Reporting.Events220;
using Scheduling.Events128;
using Scheduling.Processors25;
using Scheduling.Tests;
using Security.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Handlers33
{
    /// <summary>Immutable data transfer record for Notifications_Handlers33_Dto3.</summary>
    public record Notifications_Handlers33_Dto3(string Value, int Count, DateTime Timestamp);

}