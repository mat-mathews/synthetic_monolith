using Auth.Data;
using Auth.Events5;
using Auth.Processors319;
using BatchJobs.Events435;
using Common.Api213;
using DataAccess.Events283;
using Documents.Api439;
using Documents.Validators;
using Documents.Validators102;
using Imaging.Events;
using Portal.Contracts181;
using Portal.Models413;
using Reporting.Contracts;
using Scheduling.Processors;
using Security.Models284;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Service
{
    /// <summary>Immutable data transfer record for Imaging_Service_Response9.</summary>
    internal record Imaging_Service_Response9(string Value, int Count, DateTime Timestamp);

}