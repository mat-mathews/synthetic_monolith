using Admin.Handlers450;
using Admin.Models199;
using Admin.Shared363;
using Admin.Web4;
using Auth.Client38;
using Auth.Models23;
using BatchJobs.Contracts;
using BatchJobs.Events435;
using BatchJobs.Mappers;
using Common.Client269;
using Common.Processors142;
using Documents.Service471;
using Export.Tests;
using GalaxyWorks.Models219;
using Imaging.Events303;
using Import.Contracts296;
using Notifications.Validators252;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators201;

namespace Import.Service
{
    internal interface IImport_Service_Handler5
    {
        /// <summary>Processes the Import_Service_Handler5 operation.</summary>
        void ProcessImport_Service_Handler5();

        /// <summary>Validates the Import_Service_Handler5 state.</summary>
        bool ValidateImport_Service_Handler5();
    }

}