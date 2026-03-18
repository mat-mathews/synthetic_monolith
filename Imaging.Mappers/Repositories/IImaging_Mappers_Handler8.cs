using Admin.Client;
using Admin.Client346;
using Admin.Service;
using Auth.Api;
using Documents.Service471;
using Import.Contracts131;
using Import.Events493;
using Import.Models;
using Logging.Service382;
using Portal.Tests323;
using Portal.Tests481;
using Reporting.Service;
using Scheduling.Core273;
using Scheduling.Web196;
using Security.Processors246;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Events327;

namespace Imaging.Mappers
{
    internal interface IImaging_Mappers_Handler8
    {
        /// <summary>Processes the Imaging_Mappers_Handler8 operation.</summary>
        void ProcessImaging_Mappers_Handler8();

        /// <summary>Validates the Imaging_Mappers_Handler8 state.</summary>
        bool ValidateImaging_Mappers_Handler8();
    }

}