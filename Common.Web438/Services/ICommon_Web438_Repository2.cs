using Auth.Events;
using Auth.Models23;
using BatchJobs.Client;
using Billing.Mappers;
using Common.Api57;
using Common.Processors;
using Documents.Client58;
using Documents.Shared334;
using Imaging.Validators;
using Import.Models;
using Integration.Processors;
using Notifications.Handlers;
using Notifications.Handlers470;
using Scheduling.Shared39;
using Security.Models18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;

namespace Common.Web438
{
    public interface ICommon_Web438_Repository2
    {
        /// <summary>Processes the Common_Web438_Repository2 operation.</summary>
        void ProcessCommon_Web438_Repository2();

        /// <summary>Validates the Common_Web438_Repository2 state.</summary>
        bool ValidateCommon_Web438_Repository2();
    }

}