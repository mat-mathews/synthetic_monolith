using Admin.Contracts;
using Admin.Events;
using BatchJobs.Mappers;
using BatchJobs.Processors410;
using Documents.Shared;
using Export.Core;
using Export.Web130;
using Imaging.Models459;
using Import.Contracts;
using Integration.Handlers244;
using Integration.Mappers;
using Logging.Handlers285;
using Notifications.Events;
using Portal.Client;
using Scheduling.Contracts;
using Scheduling.Mappers48;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Processors
{
    internal interface IUtilities_Processors_Provider3
    {
        /// <summary>Processes the Utilities_Processors_Provider3 operation.</summary>
        void ProcessUtilities_Processors_Provider3();

        /// <summary>Validates the Utilities_Processors_Provider3 state.</summary>
        bool ValidateUtilities_Processors_Provider3();
    }

}