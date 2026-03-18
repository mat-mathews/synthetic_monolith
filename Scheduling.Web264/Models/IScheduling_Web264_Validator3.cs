using Admin.Mappers324;
using Auth.Api143;
using Auth.Models;
using BatchJobs.Processors500;
using Billing.Processors;
using Common.Validators;
using DataAccess.Contracts;
using Export.Models461;
using GalaxyWorks.Mappers318;
using Import.Core;
using Integration.Service477;
using Reporting.Api287;
using Reporting.Client146;
using Reporting.Events483;
using Scheduling.Events;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts192;
using Workflow.Contracts434;

namespace Scheduling.Web264
{
    public interface IScheduling_Web264_Validator3
    {
        /// <summary>Processes the Scheduling_Web264_Validator3 operation.</summary>
        void ProcessScheduling_Web264_Validator3();

        /// <summary>Validates the Scheduling_Web264_Validator3 state.</summary>
        bool ValidateScheduling_Web264_Validator3();
    }

}