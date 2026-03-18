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
    internal interface IIntegration_Handlers17_Repository
    {
        /// <summary>Processes the Integration_Handlers17_Repository operation.</summary>
        void ProcessIntegration_Handlers17_Repository();

        /// <summary>Validates the Integration_Handlers17_Repository state.</summary>
        bool ValidateIntegration_Handlers17_Repository();
    }

}