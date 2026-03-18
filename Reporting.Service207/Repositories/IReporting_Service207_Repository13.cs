using Admin.Validators336;
using Auth.Contracts402;
using Auth.Processors411;
using DataAccess.Api454;
using DataAccess.Core;
using Export.Tests62;
using Import.Models;
using Integration.Models;
using Logging.Service160;
using Notifications.Models;
using Notifications.Validators391;
using Portal.Api;
using Reporting.Contracts371;
using Scheduling.Contracts425;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client47;

namespace Reporting.Service207
{
    internal interface IReporting_Service207_Repository13
    {
        /// <summary>Processes the Reporting_Service207_Repository13 operation.</summary>
        void ProcessReporting_Service207_Repository13();

        /// <summary>Validates the Reporting_Service207_Repository13 state.</summary>
        bool ValidateReporting_Service207_Repository13();
    }

}