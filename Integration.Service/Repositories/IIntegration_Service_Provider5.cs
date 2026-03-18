using Admin.Handlers61;
using Admin.Processors;
using Admin.Validators336;
using Auth.Contracts;
using Auth.Models;
using Auth.Shared325;
using Common.Validators430;
using DataAccess.Handlers;
using GalaxyWorks.Handlers385;
using Import.Client64;
using Integration.Handlers;
using Integration.Mappers;
using Integration.Tests;
using Portal.Api51;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;
using Workflow.Web59;

namespace Integration.Service
{
    public interface IIntegration_Service_Provider5
    {
        /// <summary>Processes the Integration_Service_Provider5 operation.</summary>
        void ProcessIntegration_Service_Provider5();

        /// <summary>Validates the Integration_Service_Provider5 state.</summary>
        bool ValidateIntegration_Service_Provider5();
    }

}