using Admin.Tests;
using Auth.Events5;
using BatchJobs.Models;
using Billing.Shared312;
using Common.Processors142;
using Common.Service258;
using DataAccess.Processors;
using Documents.Models;
using Integration.Service147;
using Notifications.Validators;
using Portal.Shared;
using Portal.Web;
using Scheduling.Core273;
using Scheduling.Web221;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web59;

namespace DataAccess.Models
{
    internal interface IDataAccess_Models_Provider
    {
        /// <summary>Processes the DataAccess_Models_Provider operation.</summary>
        void ProcessDataAccess_Models_Provider();

        /// <summary>Validates the DataAccess_Models_Provider state.</summary>
        bool ValidateDataAccess_Models_Provider();
    }

}