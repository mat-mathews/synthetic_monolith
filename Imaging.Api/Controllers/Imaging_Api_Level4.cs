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
    /// <summary>Defines the possible states for Imaging_Api_Level4.</summary>
    internal enum Imaging_Api_Level4
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class ApiContext : DbContext
    {
    }

}