using Admin.Api;
using Admin.Validators336;
using Auth.Client271;
using Auth.Contracts;
using Auth.Mappers;
using Common.Processors245;
using Common.Validators430;
using Documents.Shared;
using Export.Core386;
using GalaxyWorks.Handlers385;
using Imaging.Api;
using Import.Client356;
using Import.Service496;
using Logging.Contracts373;
using Portal.Validators250;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Handlers
{
    internal interface ILogging_Handlers_Service9
    {
        /// <summary>Processes the Logging_Handlers_Service9 operation.</summary>
        void ProcessLogging_Handlers_Service9();

        /// <summary>Validates the Logging_Handlers_Service9 state.</summary>
        bool ValidateLogging_Handlers_Service9();
    }

}