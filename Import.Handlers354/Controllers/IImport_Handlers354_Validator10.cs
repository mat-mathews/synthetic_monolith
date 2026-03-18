using Admin.Processors;
using Admin.Validators240;
using BatchJobs.Api212;
using BatchJobs.Models304;
using Billing.Processors388;
using Common.Handlers;
using DataAccess.Models;
using Documents.Api132;
using Export.Processors104;
using GalaxyWorks.Data153;
using Imaging.Service;
using Import.Models;
using Integration.Core;
using Scheduling.Client;
using Scheduling.Handlers43;
using Scheduling.Tests444;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Handlers354
{
    public interface IImport_Handlers354_Validator10
    {
        /// <summary>Processes the Import_Handlers354_Validator10 operation.</summary>
        void ProcessImport_Handlers354_Validator10();

        /// <summary>Validates the Import_Handlers354_Validator10 state.</summary>
        bool ValidateImport_Handlers354_Validator10();
    }

}