using Admin.Web46;
using Auth.Api116;
using Auth.Mappers178;
using BatchJobs.Handlers;
using Common.Core118;
using Common.Validators50;
using DataAccess.Data;
using Export.Core;
using Export.Mappers;
using Import.Processors;
using Integration.Handlers;
using Integration.Service401;
using Logging.Events;
using Notifications.Handlers;
using Scheduling.Contracts425;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;
using Workflow.Handlers;

namespace Reporting.Models
{
    internal interface IReporting_Models_Repository2
    {
        /// <summary>Processes the Reporting_Models_Repository2 operation.</summary>
        void ProcessReporting_Models_Repository2();

        /// <summary>Validates the Reporting_Models_Repository2 state.</summary>
        bool ValidateReporting_Models_Repository2();
    }

}