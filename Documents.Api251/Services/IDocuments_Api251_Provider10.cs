using Admin.Api255;
using Admin.Validators;
using BatchJobs.Api501;
using Billing.Api;
using Billing.Core34;
using Billing.Handlers122;
using Billing.Shared;
using Common.Core169;
using Common.Core417;
using Common.Tests;
using Export.Models262;
using Imaging.Mappers93;
using Imaging.Shared338;
using Integration.Api;
using Integration.Processors248;
using Reporting.Processors326;
using Scheduling.Processors80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Api251
{
    public interface IDocuments_Api251_Provider10
    {
        /// <summary>Processes the Documents_Api251_Provider10 operation.</summary>
        void ProcessDocuments_Api251_Provider10();

        /// <summary>Validates the Documents_Api251_Provider10 state.</summary>
        bool ValidateDocuments_Api251_Provider10();
    }

}