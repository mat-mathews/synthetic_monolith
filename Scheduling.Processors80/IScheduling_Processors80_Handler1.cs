using Admin.Models199;
using Admin.Service339;
using Auth.Api116;
using Auth.Api143;
using Auth.Processors319;
using BatchJobs.Core;
using Billing.Models;
using Common.Events367;
using Imaging.Events303;
using Imaging.Mappers275;
using Reporting.Tests226;
using Scheduling.Tests444;
using Scheduling.Web60;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Tests;
using Workflow.Events327;

namespace Scheduling.Processors80
{
    public interface IScheduling_Processors80_Handler1
    {
        /// <summary>Processes the Scheduling_Processors80_Handler1 operation.</summary>
        void ProcessScheduling_Processors80_Handler1();

        /// <summary>Validates the Scheduling_Processors80_Handler1 state.</summary>
        bool ValidateScheduling_Processors80_Handler1();
    }

}