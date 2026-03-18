using Admin.Web;
using BatchJobs.Shared;
using Billing.Processors259;
using Common.Models381;
using Common.Processors245;
using Documents.Api439;
using Export.Processors426;
using GalaxyWorks.Client;
using Imaging.Events303;
using Imaging.Processors;
using Import.Client;
using Import.Client64;
using Integration.Handlers244;
using Portal.Tests323;
using Reporting.Events188;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Documents.Data419
{
    internal interface IDocuments_Data419_Validator2
    {
        /// <summary>Processes the Documents_Data419_Validator2 operation.</summary>
        void ProcessDocuments_Data419_Validator2();

        /// <summary>Validates the Documents_Data419_Validator2 state.</summary>
        bool ValidateDocuments_Data419_Validator2();
    }

}