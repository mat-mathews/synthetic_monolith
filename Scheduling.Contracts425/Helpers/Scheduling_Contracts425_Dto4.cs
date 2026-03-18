using Auth.Mappers208;
using BatchJobs.Api212;
using BatchJobs.Client;
using Common.Client53;
using Common.Events280;
using DataAccess.Tests282;
using Export.Processors104;
using Export.Processors449;
using GalaxyWorks.Data;
using Imaging.Core;
using Imaging.Handlers;
using Portal.Events139;
using Scheduling.Models441;
using Scheduling.Web221;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;

namespace Scheduling.Contracts425
{
    /// <summary>Immutable data transfer record for Scheduling_Contracts425_Dto4.</summary>
    internal record Scheduling_Contracts425_Dto4(string Value, int Count, DateTime Timestamp);

}