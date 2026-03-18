using Admin.Api;
using Admin.Handlers450;
using Admin.Models199;
using Admin.Web;
using Auth.Api143;
using Auth.Handlers467;
using Auth.Mappers;
using BatchJobs.Core11;
using Billing.Mappers198;
using Common.Processors142;
using Common.Tests;
using Documents.Client;
using Documents.Handlers;
using Import.Service;
using Portal.Validators;
using Scheduling.Api;
using Security.Models136;
using Security.Models420;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Shared
{
    internal interface IPortal_Shared_Validator2
    {
        /// <summary>Processes the Portal_Shared_Validator2 operation.</summary>
        void ProcessPortal_Shared_Validator2();

        /// <summary>Validates the Portal_Shared_Validator2 state.</summary>
        bool ValidatePortal_Shared_Validator2();
    }

}