using Auth.Client;
using Auth.Contracts395;
using Auth.Handlers467;
using Billing.Client73;
using Common.Web438;
using DataAccess.Handlers;
using Documents.Api132;
using Export.Processors361;
using GalaxyWorks.Client366;
using GalaxyWorks.Data153;
using Imaging.Validators;
using Import.Contracts296;
using Import.Shared;
using Portal.Data216;
using Portal.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Utilities.Data;
using Workflow.Api433;

namespace Portal.Processors52
{
    internal interface IPortal_Processors52_Factory4
    {
        /// <summary>Processes the Portal_Processors52_Factory4 operation.</summary>
        void ProcessPortal_Processors52_Factory4();

        /// <summary>Validates the Portal_Processors52_Factory4 state.</summary>
        bool ValidatePortal_Processors52_Factory4();
    }

}