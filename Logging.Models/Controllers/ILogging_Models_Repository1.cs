using Admin.Web46;
using Auth.Contracts;
using Auth.Mappers208;
using BatchJobs.Events435;
using Common.Mappers343;
using DataAccess.Contracts203;
using Documents.Events;
using Export.Client;
using Export.Handlers;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Events77;
using Import.Service291;
using Logging.Api316;
using Reporting.Models;
using Scheduling.Contracts;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Models
{
    public interface ILogging_Models_Repository1
    {
        /// <summary>Processes the Logging_Models_Repository1 operation.</summary>
        void ProcessLogging_Models_Repository1();

        /// <summary>Validates the Logging_Models_Repository1 state.</summary>
        bool ValidateLogging_Models_Repository1();
    }

}