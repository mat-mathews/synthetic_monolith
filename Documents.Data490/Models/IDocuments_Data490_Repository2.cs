using Auth.Core;
using Auth.Mappers;
using Auth.Models;
using BatchJobs.Web;
using Common.Api186;
using Common.Web438;
using DataAccess.Events;
using Documents.Data492;
using Export.Processors426;
using Export.Shared145;
using Export.Web210;
using Import.Handlers;
using Import.Handlers407;
using Integration.Processors241;
using Portal.Processors52;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Workflow.Web377;

namespace Documents.Data490
{
    internal interface IDocuments_Data490_Repository2
    {
        /// <summary>Processes the Documents_Data490_Repository2 operation.</summary>
        void ProcessDocuments_Data490_Repository2();

        /// <summary>Validates the Documents_Data490_Repository2 state.</summary>
        bool ValidateDocuments_Data490_Repository2();
    }

}