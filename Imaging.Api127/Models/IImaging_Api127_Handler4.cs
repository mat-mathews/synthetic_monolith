using Admin.Data;
using Admin.Events306;
using Admin.Handlers447;
using Admin.Validators;
using Auth.Validators;
using BatchJobs.Handlers;
using Common.Shared95;
using Documents.Shared427;
using Export.Processors111;
using GalaxyWorks.Core309;
using Integration.Processors241;
using Integration.Tests;
using Notifications.Service475;
using Notifications.Web90;
using Portal.Web;
using Reporting.Shared394;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Imaging.Api127
{
    internal interface IImaging_Api127_Handler4
    {
        /// <summary>Processes the Imaging_Api127_Handler4 operation.</summary>
        void ProcessImaging_Api127_Handler4();

        /// <summary>Validates the Imaging_Api127_Handler4 state.</summary>
        bool ValidateImaging_Api127_Handler4();
    }

}