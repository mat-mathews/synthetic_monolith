using Admin.Handlers;
using Auth.Data135;
using Auth.Events5;
using BatchJobs.Data176;
using Common.Service;
using DataAccess.Handlers;
using DataAccess.Tests286;
using Export.Models;
using Export.Service;
using Export.Web130;
using Integration.Data;
using Logging.Handlers368;
using Notifications.Service165;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;
using Workflow.Validators201;

namespace Integration.Handlers17
{
    public interface IIntegration_Handlers17_Validator14
    {
        /// <summary>Processes the Integration_Handlers17_Validator14 operation.</summary>
        void ProcessIntegration_Handlers17_Validator14();

        /// <summary>Validates the Integration_Handlers17_Validator14 state.</summary>
        bool ValidateIntegration_Handlers17_Validator14();
    }

}