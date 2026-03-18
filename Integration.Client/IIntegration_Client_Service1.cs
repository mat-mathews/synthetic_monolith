using Admin.Client346;
using Admin.Data;
using Admin.Handlers450;
using Auth.Api116;
using Auth.Api143;
using Auth.Models236;
using Common.Api;
using DataAccess.Api;
using DataAccess.Data36;
using DataAccess.Mappers;
using Documents.Service;
using Export.Core168;
using Imaging.Client331;
using Logging.Data29;
using Notifications.Models;
using Scheduling.Service211;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared;

namespace Integration.Client
{
    internal interface IIntegration_Client_Service1
    {
        /// <summary>Processes the Integration_Client_Service1 operation.</summary>
        void ProcessIntegration_Client_Service1();

        /// <summary>Validates the Integration_Client_Service1 state.</summary>
        bool ValidateIntegration_Client_Service1();
    }

}