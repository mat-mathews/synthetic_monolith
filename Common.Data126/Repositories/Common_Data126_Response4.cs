using Admin.Data465;
using Admin.Models476;
using Auth.Events5;
using Auth.Mappers;
using Auth.Models23;
using Common.Core417;
using GalaxyWorks.Shared437;
using Imaging.Models184;
using Logging.Contracts;
using Notifications.Validators252;
using Notifications.Web90;
using Portal.Data216;
using Reporting.Processors495;
using Scheduling.Tests444;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Client;

namespace Common.Data126
{
    /// <summary>Immutable data transfer record for Common_Data126_Response4.</summary>
    public record Common_Data126_Response4(string Value, int Count, DateTime Timestamp);

}