using Admin.Data117;
using BatchJobs.Processors500;
using Common.Processors;
using DataAccess.Events283;
using Documents.Service215;
using Export.Web479;
using GalaxyWorks.Events;
using GalaxyWorks.Events77;
using GalaxyWorks.Models;
using Integration.Core;
using Reporting.Client;
using Reporting.Web345;
using Scheduling.Handlers;
using Scheduling.Tests444;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;

namespace DataAccess.Core
{
    /// <summary>Immutable data transfer record for DataAccess_Core_Dto7.</summary>
    public record DataAccess_Core_Dto7(string Value, int Count, DateTime Timestamp);

}