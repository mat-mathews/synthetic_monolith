using Admin.Data408;
using Admin.Handlers450;
using Common.Client53;
using Common.Data21;
using Documents.Events451;
using Documents.Processors;
using GalaxyWorks.Data453;
using GalaxyWorks.Tests;
using GalaxyWorks.Tests445;
using Import.Client64;
using Import.Validators;
using Portal.Tests173;
using Reporting.Processors;
using Scheduling.Mappers442;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;
using Workflow.Contracts330;

namespace Import.Processors
{
    public interface IImport_Processors_Provider5
    {
        /// <summary>Processes the Import_Processors_Provider5 operation.</summary>
        void ProcessImport_Processors_Provider5();

        /// <summary>Validates the Import_Processors_Provider5 state.</summary>
        bool ValidateImport_Processors_Provider5();
    }

}