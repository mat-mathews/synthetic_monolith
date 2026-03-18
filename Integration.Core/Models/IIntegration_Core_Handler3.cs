using Admin.Client177;
using Admin.Handlers447;
using Admin.Service456;
using Auth.Client249;
using BatchJobs.Client109;
using BatchJobs.Contracts399;
using Billing.Api497;
using DataAccess.Validators88;
using DataAccess.Web200;
using Export.Api49;
using Export.Shared145;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Core309;
using Portal.Contracts181;
using Reporting.Web;
using Security.Client137;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Integration.Core
{
    internal interface IIntegration_Core_Handler3
    {
        /// <summary>Processes the Integration_Core_Handler3 operation.</summary>
        void ProcessIntegration_Core_Handler3();

        /// <summary>Validates the Integration_Core_Handler3 state.</summary>
        bool ValidateIntegration_Core_Handler3();
    }

}