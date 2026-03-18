using Admin.Client;
using Admin.Service456;
using Auth.Api;
using Auth.Handlers;
using BatchJobs.Tests270;
using Imaging.Models184;
using Imaging.Shared338;
using Import.Web;
using Integration.Service477;
using Notifications.Contracts;
using Notifications.Mappers110;
using Portal.Events139;
using Reporting.Events220;
using Scheduling.Events;
using Security.Contracts;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    /// <summary>Immutable data transfer record for Common_Models_Command2.</summary>
    public record Common_Models_Command2(string Value, int Count, DateTime Timestamp);

}