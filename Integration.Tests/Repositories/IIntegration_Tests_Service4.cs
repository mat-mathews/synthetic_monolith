using Admin.Contracts;
using Admin.Data408;
using Auth.Api116;
using Auth.Processors411;
using BatchJobs.Mappers;
using Common.Contracts279;
using Common.Data126;
using Common.Service;
using Imaging.Events;
using Portal.Api352;
using Portal.Models413;
using Reporting.Events;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Workflow.Tests27;
using Workflow.Web;

namespace Integration.Tests
{
    internal interface IIntegration_Tests_Service4
    {
        /// <summary>Processes the Integration_Tests_Service4 operation.</summary>
        void ProcessIntegration_Tests_Service4();

        /// <summary>Validates the Integration_Tests_Service4 state.</summary>
        bool ValidateIntegration_Tests_Service4();
    }

}