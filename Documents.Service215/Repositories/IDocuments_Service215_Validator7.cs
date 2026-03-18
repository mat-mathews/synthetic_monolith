using Admin.Events235;
using Admin.Events306;
using Admin.Validators336;
using Auth.Events5;
using Auth.Events78;
using BatchJobs.Handlers;
using BatchJobs.Handlers443;
using Billing.Contracts;
using Common.Api;
using Common.Api57;
using DataAccess.Api341;
using DataAccess.Shared189;
using GalaxyWorks.Tests445;
using Imaging.Shared;
using Import.Client356;
using Logging.Processors;
using Portal.Data216;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Service215
{
    public interface IDocuments_Service215_Validator7
    {
        /// <summary>Processes the Documents_Service215_Validator7 operation.</summary>
        void ProcessDocuments_Service215_Validator7();

        /// <summary>Validates the Documents_Service215_Validator7 state.</summary>
        bool ValidateDocuments_Service215_Validator7();
    }

}