using Admin.Mappers;
using Admin.Service;
using Auth.Api;
using Auth.Models;
using BatchJobs.Contracts;
using Common.Processors142;
using DataAccess.Handlers482;
using Documents.Shared427;
using Export.Processors;
using GalaxyWorks.Client366;
using Imaging.Mappers;
using Integration.Contracts290;
using Logging.Handlers285;
using Portal.Api99;
using Reporting.Service;
using Scheduling.Models260;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Mappers
{
    /// <summary>Immutable data transfer record for Scheduling_Mappers_Request4.</summary>
    internal record Scheduling_Mappers_Request4(string Value, int Count, DateTime Timestamp);

}