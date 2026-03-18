using Auth.Api143;
using Auth.Client249;
using Auth.Processors400;
using DataAccess.Api294;
using Documents.Models;
using Export.Processors79;
using Imaging.Core204;
using Imaging.Shared;
using Import.Client65;
using Integration.Tests86;
using Notifications.Mappers;
using Portal.Tests173;
using Scheduling.Models441;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;
using Utilities.Models41;

namespace Reporting.Api393
{
    /// <summary>Immutable data transfer record for Reporting_Api393_ViewModel.</summary>
    internal record Reporting_Api393_ViewModel(string Value, int Count, DateTime Timestamp);

}