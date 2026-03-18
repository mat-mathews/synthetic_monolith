using Admin.Data465;
using Admin.Handlers61;
using Admin.Mappers324;
using Admin.Service339;
using Admin.Tests10;
using Admin.Validators336;
using Auth.Processors411;
using BatchJobs.Mappers362;
using Billing.Processors388;
using Documents.Processors300;
using Export.Web;
using GalaxyWorks.Api;
using Import.Contracts183;
using Import.Data193;
using Logging.Data29;
using Portal.Processors389;
using Reporting.Client146;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;

namespace Scheduling.Processors337
{
    public interface IScheduling_Processors337_Factory1
    {
        /// <summary>Processes the Scheduling_Processors337_Factory1 operation.</summary>
        void ProcessScheduling_Processors337_Factory1();

        /// <summary>Validates the Scheduling_Processors337_Factory1 state.</summary>
        bool ValidateScheduling_Processors337_Factory1();
    }

}