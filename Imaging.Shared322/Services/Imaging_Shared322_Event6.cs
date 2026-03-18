using Admin.Models;
using Admin.Service;
using Admin.Validators;
using Auth.Client38;
using Auth.Contracts395;
using BatchJobs.Handlers;
using BatchJobs.Handlers443;
using BatchJobs.Processors410;
using Common.Validators50;
using DataAccess.Handlers482;
using Export.Service;
using Imaging.Service;
using Imaging.Shared;
using Import.Validators;
using Notifications.Processors20;
using Notifications.Tests195;
using Scheduling.Contracts;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Shared322
{
    /// <summary>Immutable data transfer record for Imaging_Shared322_Event6.</summary>
    public record Imaging_Shared322_Event6(string Value, int Count, DateTime Timestamp);

}