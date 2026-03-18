using Admin.Contracts;
using Admin.Core121;
using Admin.Handlers;
using Admin.Service339;
using BatchJobs.Models304;
using Common.Processors;
using Export.Data344;
using GalaxyWorks.Service293;
using Imaging.Contracts89;
using Import.Models;
using Integration.Handlers423;
using Portal.Client;
using Portal.Contracts170;
using Portal.Handlers26;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Handlers268;

namespace Import.Validators
{
    internal interface IImport_Validators_Repository4
    {
        /// <summary>Processes the Import_Validators_Repository4 operation.</summary>
        void ProcessImport_Validators_Repository4();

        /// <summary>Validates the Import_Validators_Repository4 state.</summary>
        bool ValidateImport_Validators_Repository4();
    }

}