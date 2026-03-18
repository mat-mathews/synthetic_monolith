using Admin.Handlers61;
using Auth.Models23;
using BatchJobs.Api;
using BatchJobs.Shared;
using Documents.Api;
using Documents.Api156;
using Export.Processors361;
using GalaxyWorks.Contracts392;
using Notifications.Tests195;
using Reporting.Handlers347;
using Scheduling.Models260;
using Security.Api;
using Security.Contracts72;
using Security.Models;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests222;

namespace Notifications.Core
{
    public interface INotifications_Core_Repository13
    {
        /// <summary>Processes the Notifications_Core_Repository13 operation.</summary>
        void ProcessNotifications_Core_Repository13();

        /// <summary>Validates the Notifications_Core_Repository13 state.</summary>
        bool ValidateNotifications_Core_Repository13();
    }

}