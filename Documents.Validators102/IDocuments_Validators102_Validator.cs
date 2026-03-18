using Admin.Data117;
using Admin.Service339;
using Admin.Service364;
using Billing.Handlers;
using Common.Service;
using GalaxyWorks.Handlers;
using Imaging.Validators108;
using Integration.Contracts290;
using Integration.Service477;
using Notifications.Shared;
using Portal.Validators;
using Reporting.Mappers239;
using Scheduling.Tests;
using Security.Core243;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service;
using Workflow.Tests222;

namespace Documents.Validators102
{
    internal interface IDocuments_Validators102_Validator
    {
        /// <summary>Processes the Documents_Validators102_Validator operation.</summary>
        void ProcessDocuments_Validators102_Validator();

        /// <summary>Validates the Documents_Validators102_Validator state.</summary>
        bool ValidateDocuments_Validators102_Validator();
    }

}