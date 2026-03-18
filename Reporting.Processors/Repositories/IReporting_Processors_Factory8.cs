using Auth.Api143;
using Auth.Web70;
using BatchJobs.Client;
using BatchJobs.Client267;
using Common.Models381;
using DataAccess.Data474;
using Imaging.Events;
using Import.Contracts;
using Integration.Tests92;
using Notifications.Service;
using Notifications.Validators391;
using Reporting.Client146;
using Scheduling.Models441;
using Scheduling.Tests85;
using Security.Events288;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Reporting.Processors
{
    internal interface IReporting_Processors_Factory8
    {
        /// <summary>Processes the Reporting_Processors_Factory8 operation.</summary>
        void ProcessReporting_Processors_Factory8();

        /// <summary>Validates the Reporting_Processors_Factory8 state.</summary>
        bool ValidateReporting_Processors_Factory8();
    }

}