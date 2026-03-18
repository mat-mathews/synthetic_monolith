using Auth.Core;
using Common.Api213;
using Common.Models381;
using DataAccess.Contracts404;
using Documents.Processors133;
using Export.Web130;
using Import.Client;
using Import.Handlers167;
using Import.Service291;
using Logging.Service382;
using Reporting.Events317;
using Scheduling.Contracts;
using Scheduling.Handlers43;
using Scheduling.Validators;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;

namespace Export.Service30
{
    internal interface IExport_Service30_Provider1
    {
        /// <summary>Processes the Export_Service30_Provider1 operation.</summary>
        void ProcessExport_Service30_Provider1();

        /// <summary>Validates the Export_Service30_Provider1 state.</summary>
        bool ValidateExport_Service30_Provider1();
    }

}