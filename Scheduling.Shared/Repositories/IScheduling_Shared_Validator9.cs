using Admin.Contracts;
using Admin.Validators;
using Auth.Contracts402;
using Auth.Processors319;
using Common.Events;
using Common.Events280;
using Common.Validators430;
using Documents.Shared452;
using Documents.Tests171;
using Import.Service429;
using Import.Service496;
using Import.Shared;
using Integration.Events;
using Notifications.Data348;
using Portal.Web158;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;
using Workflow.Client;

namespace Scheduling.Shared
{
    public interface IScheduling_Shared_Validator9
    {
        /// <summary>Processes the Scheduling_Shared_Validator9 operation.</summary>
        void ProcessScheduling_Shared_Validator9();

        /// <summary>Validates the Scheduling_Shared_Validator9 state.</summary>
        bool ValidateScheduling_Shared_Validator9();
    }

}