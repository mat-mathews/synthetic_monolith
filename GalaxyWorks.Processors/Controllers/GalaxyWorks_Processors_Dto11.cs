using Admin.Data117;
using Auth.Api143;
using Auth.Contracts;
using Auth.Core;
using Auth.Mappers;
using Auth.Processors319;
using BatchJobs.Contracts;
using Documents.Service;
using Export.Service30;
using GalaxyWorks.Data96;
using Imaging.Client331;
using Integration.Handlers423;
using Integration.Mappers;
using Integration.Processors321;
using Notifications.Service165;
using Reporting.Handlers;
using Scheduling.Mappers48;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Processors
{
    /// <summary>Immutable data transfer record for GalaxyWorks_Processors_Dto11.</summary>
    public record GalaxyWorks_Processors_Dto11(string Value, int Count, DateTime Timestamp);

}