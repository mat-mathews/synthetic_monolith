using Admin.Web;
using Auth.Client271;
using Auth.Handlers281;
using Billing.Handlers101;
using Billing.Shared312;
using Common.Shared95;
using Common.Web438;
using DataAccess.Shared189;
using GalaxyWorks.Contracts392;
using Import.Contracts;
using Import.Data100;
using Import.Tests119;
using Integration.Handlers244;
using Integration.Processors248;
using Integration.Tests;
using Portal.Validators227;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api;

namespace Documents.Events451
{
    internal interface IDocuments_Events451_Repository2
    {
        /// <summary>Processes the Documents_Events451_Repository2 operation.</summary>
        void ProcessDocuments_Events451_Repository2();

        /// <summary>Validates the Documents_Events451_Repository2 state.</summary>
        bool ValidateDocuments_Events451_Repository2();
    }

    public class Events451Context : DbContext
    {
    }

}