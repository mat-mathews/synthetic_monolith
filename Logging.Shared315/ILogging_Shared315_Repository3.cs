using Admin.Web154;
using Auth.Client38;
using Auth.Mappers178;
using Billing.Events;
using Documents.Api;
using Documents.Processors133;
using Export.Models461;
using Imaging.Core;
using Imaging.Tests328;
using Import.Contracts180;
using Import.Handlers167;
using Integration.Tests92;
using Portal.Data;
using Scheduling.Web19;
using Security.Events;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Events;

namespace Logging.Shared315
{
    public interface ILogging_Shared315_Repository3
    {
        /// <summary>Processes the Logging_Shared315_Repository3 operation.</summary>
        void ProcessLogging_Shared315_Repository3();

        /// <summary>Validates the Logging_Shared315_Repository3 state.</summary>
        bool ValidateLogging_Shared315_Repository3();
    }

}