using Auth.Core2;
using Auth.Events78;
using Auth.Handlers209;
using Common.Shared;
using DataAccess.Data474;
using GalaxyWorks.Service;
using GalaxyWorks.Web;
using Imaging.Handlers;
using Integration.Core;
using Notifications.Contracts;
using Notifications.Events42;
using Portal.Service378;
using Security.Client349;
using Security.Mappers313;
using Security.Service;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;
using Utilities.Web398;

namespace BatchJobs.Processors
{
    internal interface IBatchJobs_Processors_Validator7
    {
        /// <summary>Processes the BatchJobs_Processors_Validator7 operation.</summary>
        void ProcessBatchJobs_Processors_Validator7();

        /// <summary>Validates the BatchJobs_Processors_Validator7 state.</summary>
        bool ValidateBatchJobs_Processors_Validator7();
    }

}