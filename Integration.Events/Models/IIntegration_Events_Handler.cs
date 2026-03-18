using Admin.Handlers61;
using Admin.Web;
using Auth.Api;
using Billing.Validators174;
using Common.Api57;
using DataAccess.Tests282;
using Documents.Service;
using Imaging.Api127;
using Imaging.Mappers;
using Imaging.Service;
using Integration.Service477;
using Reporting.Events317;
using Scheduling.Models;
using Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;
using Workflow.Models;

namespace Integration.Events
{
    internal interface IIntegration_Events_Handler
    {
        /// <summary>Processes the Integration_Events_Handler operation.</summary>
        void ProcessIntegration_Events_Handler();

        /// <summary>Validates the Integration_Events_Handler state.</summary>
        bool ValidateIntegration_Events_Handler();
    }

}