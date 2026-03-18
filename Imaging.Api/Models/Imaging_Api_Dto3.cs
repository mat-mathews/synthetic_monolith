using Admin.Handlers;
using Admin.Web154;
using Auth.Contracts;
using Auth.Handlers209;
using Auth.Models236;
using BatchJobs.Shared;
using Billing.Service;
using Common.Models;
using Integration.Events;
using Integration.Tests;
using Notifications.Handlers470;
using Notifications.Web;
using Reporting.Api;
using Reporting.Data;
using Reporting.Shared394;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors440;
using Workflow.Api;
using Workflow.Client351;

namespace Imaging.Api
{
    /// <summary>Immutable data transfer record for Imaging_Api_Dto3.</summary>
    internal record Imaging_Api_Dto3(string Value, int Count, DateTime Timestamp);

}