using Admin.Data;
using Admin.Data117;
using Admin.Validators37;
using Auth.Client38;
using Auth.Events;
using Common.Validators430;
using Documents.Service;
using Export.Validators152;
using GalaxyWorks.Client;
using Import.Events493;
using Import.Shared;
using Integration.Mappers242;
using Integration.Processors;
using Reporting.Events317;
using Scheduling.Validators;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Validators;
using Workflow.Web59;

namespace Integration.Models
{
    public interface IIntegration_Models_Factory
    {
        /// <summary>Processes the Integration_Models_Factory operation.</summary>
        void ProcessIntegration_Models_Factory();

        /// <summary>Validates the Integration_Models_Factory state.</summary>
        bool ValidateIntegration_Models_Factory();
    }

}