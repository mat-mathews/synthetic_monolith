using Auth.Contracts;
using BatchJobs.Handlers443;
using BatchJobs.Validators;
using Billing.Handlers101;
using DataAccess.Validators254;
using Documents.Service;
using Documents.Shared334;
using Documents.Validators;
using Integration.Processors241;
using Notifications.Core;
using Notifications.Service;
using Portal.Validators125;
using Reporting.Contracts371;
using Scheduling.Handlers;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;

namespace Imaging.Handlers
{
    internal interface IImaging_Handlers_Provider1
    {
        /// <summary>Processes the Imaging_Handlers_Provider1 operation.</summary>
        void ProcessImaging_Handlers_Provider1();

        /// <summary>Validates the Imaging_Handlers_Provider1 state.</summary>
        bool ValidateImaging_Handlers_Provider1();
    }

}