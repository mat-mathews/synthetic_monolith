using Admin.Client177;
using Admin.Shared14;
using DataAccess.Shared189;
using Export.Events;
using Export.Processors449;
using Export.Service205;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Contracts485;
using Imaging.Events424;
using Imaging.Validators108;
using Integration.Contracts;
using Logging.Data29;
using Logging.Tests;
using Notifications.Web90;
using Reporting.Events317;
using Reporting.Mappers;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Mappers
{
    /// <summary>Immutable data transfer record for GalaxyWorks_Mappers_Response.</summary>
    public record GalaxyWorks_Mappers_Response(string Value, int Count, DateTime Timestamp);

    public class MappersContext : DbContext
    {
    }

}