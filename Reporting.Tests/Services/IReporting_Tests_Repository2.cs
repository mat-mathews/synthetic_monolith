using Admin.Handlers61;
using Admin.Service339;
using BatchJobs.Api212;
using BatchJobs.Processors;
using BatchJobs.Tests270;
using Common.Mappers343;
using Documents.Api156;
using GalaxyWorks.Data224;
using Import.Client356;
using Reporting.Contracts371;
using Reporting.Mappers;
using Scheduling.Events;
using Scheduling.Events128;
using Security.Client;
using Security.Events288;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;

namespace Reporting.Tests
{
    public interface IReporting_Tests_Repository2
    {
        /// <summary>Processes the Reporting_Tests_Repository2 operation.</summary>
        void ProcessReporting_Tests_Repository2();

        /// <summary>Validates the Reporting_Tests_Repository2 state.</summary>
        bool ValidateReporting_Tests_Repository2();
    }

}