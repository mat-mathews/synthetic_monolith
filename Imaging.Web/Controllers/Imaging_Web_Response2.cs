using Admin.Api;
using Auth.Contracts402;
using Auth.Core140;
using BatchJobs.Contracts399;
using Billing.Events;
using Billing.Service;
using Billing.Service302;
using Common.Processors245;
using DataAccess.Tests;
using Documents.Data;
using Documents.Processors133;
using Export.Mappers;
using Export.Processors361;
using Export.Service;
using Imaging.Api127;
using Import.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Imaging.Web
{
    /// <summary>Immutable data transfer record for Imaging_Web_Response2.</summary>
    public record Imaging_Web_Response2(string Value, int Count, DateTime Timestamp);

}