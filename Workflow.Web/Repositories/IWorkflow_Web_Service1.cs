using Admin.Client346;
using Admin.Service364;
using Admin.Validators;
using Auth.Handlers209;
using Billing.Validators174;
using Documents.Client58;
using Documents.Core357;
using Export.Events276;
using Export.Tests62;
using Imaging.Contracts;
using Integration.Service401;
using Logging.Api;
using Logging.Client;
using Notifications.Contracts;
using Notifications.Models277;
using Reporting.Service207;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Web
{
    internal interface IWorkflow_Web_Service1
    {
        /// <summary>Processes the Workflow_Web_Service1 operation.</summary>
        void ProcessWorkflow_Web_Service1();

        /// <summary>Validates the Workflow_Web_Service1 state.</summary>
        bool ValidateWorkflow_Web_Service1();
    }

}