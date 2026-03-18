using Admin.Mappers;
using Admin.Models;
using Admin.Models199;
using Auth.Core140;
using BatchJobs.Tests270;
using Billing.Service302;
using Billing.Tests;
using Common.Mappers;
using Documents.Shared;
using Export.Events276;
using GalaxyWorks.Client;
using Imaging.Client261;
using Imaging.Mappers93;
using Imaging.Models;
using Reporting.Core;
using Scheduling.Processors80;
using Security.Events288;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Processors79
{
    public interface IExport_Processors79_Validator9
    {
        /// <summary>Processes the Export_Processors79_Validator9 operation.</summary>
        void ProcessExport_Processors79_Validator9();

        /// <summary>Validates the Export_Processors79_Validator9 state.</summary>
        bool ValidateExport_Processors79_Validator9();
    }

}