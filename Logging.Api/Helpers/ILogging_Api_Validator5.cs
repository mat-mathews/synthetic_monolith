using Auth.Api143;
using BatchJobs.Contracts;
using BatchJobs.Data176;
using Billing.Events;
using Common.Models;
using Common.Models381;
using DataAccess.Api98;
using Documents.Tests106;
using GalaxyWorks.Handlers385;
using Integration.Handlers244;
using Portal.Processors;
using Reporting.Api287;
using Reporting.Events;
using Scheduling.Client187;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators138;

namespace Logging.Api
{
    internal interface ILogging_Api_Validator5
    {
        /// <summary>Processes the Logging_Api_Validator5 operation.</summary>
        void ProcessLogging_Api_Validator5();

        /// <summary>Validates the Logging_Api_Validator5 state.</summary>
        bool ValidateLogging_Api_Validator5();
    }

    public class ApiContext : DbContext
    {
    }

}