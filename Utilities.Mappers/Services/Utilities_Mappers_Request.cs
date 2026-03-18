using Admin.Models199;
using Admin.Processors35;
using Admin.Service;
using Auth.Contracts;
using Common.Core169;
using Imaging.Service;
using Import.Core;
using Integration.Processors;
using Logging.Tests;
using Notifications.Core166;
using Notifications.Web308;
using Portal.Validators;
using Reporting.Processors326;
using Scheduling.Models;
using Security.Core243;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers462;
using Utilities.Web398;

namespace Utilities.Mappers
{
    /// <summary>Immutable data transfer record for Utilities_Mappers_Request.</summary>
    internal record Utilities_Mappers_Request(string Value, int Count, DateTime Timestamp);

}