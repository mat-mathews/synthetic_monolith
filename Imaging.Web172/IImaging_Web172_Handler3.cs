using Admin.Api255;
using Admin.Handlers450;
using Admin.Handlers61;
using Auth.Client;
using Auth.Validators87;
using Billing.Processors388;
using Common.Processors;
using DataAccess.Handlers;
using Documents.Validators102;
using Documents.Web164;
using Export.Service;
using GalaxyWorks.Handlers84;
using Reporting.Api;
using Reporting.Client146;
using Security.Api320;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Utilities.Service;
using Workflow.Events327;

namespace Imaging.Web172
{
    public interface IImaging_Web172_Handler3
    {
        /// <summary>Processes the Imaging_Web172_Handler3 operation.</summary>
        void ProcessImaging_Web172_Handler3();

        /// <summary>Validates the Imaging_Web172_Handler3 state.</summary>
        bool ValidateImaging_Web172_Handler3();
    }

}