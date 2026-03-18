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
    internal interface IImaging_Api_Factory2
    {
        /// <summary>Processes the Imaging_Api_Factory2 operation.</summary>
        void ProcessImaging_Api_Factory2();

        /// <summary>Validates the Imaging_Api_Factory2 state.</summary>
        bool ValidateImaging_Api_Factory2();
    }

}