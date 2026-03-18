using Admin.Api;
using Auth.Contracts402;
using Auth.Core140;
using BatchJobs.Contracts399;
using Billing.Events;
using Billing.Service;
using Billing.Service302;
using Common.Processors245;
using DataAccess.Tests;
using Documents.Data;
using Documents.Processors133;
using Export.Mappers;
using Export.Processors361;
using Export.Service;
using Imaging.Api127;
using Import.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Imaging.Web
{
    internal interface IImaging_Web_Handler5
    {
        /// <summary>Processes the Imaging_Web_Handler5 operation.</summary>
        void ProcessImaging_Web_Handler5();

        /// <summary>Validates the Imaging_Web_Handler5 state.</summary>
        bool ValidateImaging_Web_Handler5();
    }

}