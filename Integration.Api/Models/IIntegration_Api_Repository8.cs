using Admin.Client346;
using Admin.Mappers324;
using Auth.Api143;
using Auth.Processors;
using Documents.Service471;
using GalaxyWorks.Shared;
using Imaging.Shared;
using Imaging.Validators108;
using Import.Client64;
using Integration.Handlers;
using Integration.Service;
using Logging.Client405;
using Portal.Core8;
using Security.Client137;
using Security.Client353;
using Security.Handlers460;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service;

namespace Integration.Api
{
    public interface IIntegration_Api_Repository8
    {
        /// <summary>Processes the Integration_Api_Repository8 operation.</summary>
        void ProcessIntegration_Api_Repository8();

        /// <summary>Validates the Integration_Api_Repository8 state.</summary>
        bool ValidateIntegration_Api_Repository8();
    }

}