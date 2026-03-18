using Auth.Client;
using Auth.Core;
using Common.Core118;
using Common.Data21;
using DataAccess.Client82;
using Documents.Shared487;
using Export.Processors468;
using GalaxyWorks.Data153;
using GalaxyWorks.Tests445;
using Integration.Processors241;
using Logging.Mappers157;
using Portal.Data;
using Reporting.Client146;
using Scheduling.Contracts425;
using Scheduling.Processors335;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts;

namespace Integration.Shared
{
    internal interface IIntegration_Shared_Validator3
    {
        /// <summary>Processes the Integration_Shared_Validator3 operation.</summary>
        void ProcessIntegration_Shared_Validator3();

        /// <summary>Validates the Integration_Shared_Validator3 state.</summary>
        bool ValidateIntegration_Shared_Validator3();
    }

}