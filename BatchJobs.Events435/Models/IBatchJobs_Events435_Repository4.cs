using Admin.Shared14;
using Admin.Shared310;
using Admin.Web46;
using BatchJobs.Client109;
using Billing.Mappers124;
using Billing.Processors388;
using Billing.Web;
using Documents.Tests106;
using GalaxyWorks.Contracts485;
using Imaging.Models459;
using Logging.Handlers141;
using Notifications.Data348;
using Portal.Mappers233;
using Portal.Service489;
using Scheduling.Api185;
using Scheduling.Core480;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web;

namespace BatchJobs.Events435
{
    internal interface IBatchJobs_Events435_Repository4
    {
        /// <summary>Processes the BatchJobs_Events435_Repository4 operation.</summary>
        void ProcessBatchJobs_Events435_Repository4();

        /// <summary>Validates the BatchJobs_Events435_Repository4 state.</summary>
        bool ValidateBatchJobs_Events435_Repository4();
    }

}