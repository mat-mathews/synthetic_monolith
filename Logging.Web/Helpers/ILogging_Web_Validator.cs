using Auth.Api;
using Auth.Events78;
using Auth.Handlers;
using DataAccess.Client82;
using DataAccess.Models;
using GalaxyWorks.Core;
using GalaxyWorks.Core309;
using Imaging.Tests;
using Import.Handlers167;
using Import.Tests;
using Logging.Api;
using Logging.Validators359;
using Portal.Tests;
using Reporting.Events483;
using Security.Core274;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;
using Workflow.Mappers370;

namespace Logging.Web
{
    public interface ILogging_Web_Validator
    {
        /// <summary>Processes the Logging_Web_Validator operation.</summary>
        void ProcessLogging_Web_Validator();

        /// <summary>Validates the Logging_Web_Validator state.</summary>
        bool ValidateLogging_Web_Validator();
    }

}