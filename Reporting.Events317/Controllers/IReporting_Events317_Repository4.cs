using Admin.Events235;
using Admin.Processors35;
using Admin.Web4;
using DataAccess.Shared189;
using Export.Processors104;
using GalaxyWorks.Api390;
using Imaging.Mappers93;
using Logging.Models379;
using Logging.Shared315;
using Notifications.Core;
using Portal.Shared;
using Scheduling.Models260;
using Scheduling.Models342;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;
using Workflow.Data;
using Workflow.Tests222;

namespace Reporting.Events317
{
    public interface IReporting_Events317_Repository4
    {
        /// <summary>Processes the Reporting_Events317_Repository4 operation.</summary>
        void ProcessReporting_Events317_Repository4();

        /// <summary>Validates the Reporting_Events317_Repository4 state.</summary>
        bool ValidateReporting_Events317_Repository4();
    }

}