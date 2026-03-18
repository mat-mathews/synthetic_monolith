using Admin.Handlers61;
using Auth.Events5;
using Auth.Handlers;
using Auth.Handlers281;
using BatchJobs.Models304;
using Billing.Handlers122;
using Export.Api49;
using Export.Service30;
using Export.Web130;
using Integration.Models;
using Logging.Data29;
using Logging.Events289;
using Portal.Validators250;
using Reporting.Handlers347;
using Security.Handlers162;
using Security.Processors246;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service161;

namespace Common.Handlers
{
    internal interface ICommon_Handlers_Validator4
    {
        /// <summary>Processes the Common_Handlers_Validator4 operation.</summary>
        void ProcessCommon_Handlers_Validator4();

        /// <summary>Validates the Common_Handlers_Validator4 state.</summary>
        bool ValidateCommon_Handlers_Validator4();
    }

}