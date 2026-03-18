using Admin.Client177;
using Admin.Web154;
using Auth.Core2;
using BatchJobs.Api501;
using Common.Core169;
using Common.Mappers343;
using Common.Processors142;
using GalaxyWorks.Service293;
using Import.Contracts296;
using Integration.Service;
using Integration.Tests86;
using Logging.Client;
using Logging.Events;
using Notifications.Mappers;
using Notifications.Tests;
using Security.Client;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;

namespace BatchJobs.Events
{
    internal interface IBatchJobs_Events_Validator5
    {
        /// <summary>Processes the BatchJobs_Events_Validator5 operation.</summary>
        void ProcessBatchJobs_Events_Validator5();

        /// <summary>Validates the BatchJobs_Events_Validator5 state.</summary>
        bool ValidateBatchJobs_Events_Validator5();
    }

}