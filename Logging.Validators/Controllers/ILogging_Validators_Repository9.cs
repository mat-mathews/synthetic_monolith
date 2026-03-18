using Admin.Models;
using Admin.Service;
using Admin.Service456;
using DataAccess.Data;
using Documents.Data;
using Documents.Tests;
using Import.Api272;
using Import.Contracts180;
using Import.Service;
using Integration.Contracts290;
using Integration.Events;
using Logging.Events;
using Notifications.Core;
using Reporting.Contracts371;
using Scheduling.Processors335;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Validators
{
    public interface ILogging_Validators_Repository9
    {
        /// <summary>Processes the Logging_Validators_Repository9 operation.</summary>
        void ProcessLogging_Validators_Repository9();

        /// <summary>Validates the Logging_Validators_Repository9 state.</summary>
        bool ValidateLogging_Validators_Repository9();
    }

}