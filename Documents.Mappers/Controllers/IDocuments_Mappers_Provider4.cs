using Admin.Client346;
using Admin.Contracts;
using Admin.Service;
using Auth.Handlers209;
using Auth.Mappers178;
using Billing.Client;
using Billing.Core34;
using Billing.Validators;
using Common.Mappers343;
using Common.Shared;
using Common.Web438;
using Export.Shared332;
using GalaxyWorks.Api390;
using Integration.Tests45;
using Logging.Handlers285;
using Security.Api;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;

namespace Documents.Mappers
{
    internal interface IDocuments_Mappers_Provider4
    {
        /// <summary>Processes the Documents_Mappers_Provider4 operation.</summary>
        void ProcessDocuments_Mappers_Provider4();

        /// <summary>Validates the Documents_Mappers_Provider4 state.</summary>
        bool ValidateDocuments_Mappers_Provider4();
    }

}