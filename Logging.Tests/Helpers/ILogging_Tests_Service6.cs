using Admin.Data408;
using Admin.Shared310;
using Auth.Data135;
using Auth.Handlers209;
using BatchJobs.Processors410;
using Billing.Shared149;
using Common.Core;
using Imaging.Events303;
using Integration.Models;
using Logging.Client405;
using Notifications.Handlers;
using Portal.Service378;
using Portal.Tests481;
using Reporting.Service207;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client;

namespace Logging.Tests
{
    internal interface ILogging_Tests_Service6
    {
        /// <summary>Processes the Logging_Tests_Service6 operation.</summary>
        void ProcessLogging_Tests_Service6();

        /// <summary>Validates the Logging_Tests_Service6 state.</summary>
        bool ValidateLogging_Tests_Service6();
    }

}