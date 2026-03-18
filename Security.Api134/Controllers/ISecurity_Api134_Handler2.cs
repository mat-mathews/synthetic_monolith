using Admin.Events;
using Admin.Mappers324;
using Admin.Service364;
using Admin.Tests;
using BatchJobs.Tests270;
using Documents.Data484;
using Documents.Web;
using GalaxyWorks.Processors16;
using Import.Client7;
using Portal.Processors52;
using Portal.Service378;
using Reporting.Api;
using Reporting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Processors;
using Workflow.Validators;
using Workflow.Web;

namespace Security.Api134
{
    internal interface ISecurity_Api134_Handler2
    {
        /// <summary>Processes the Security_Api134_Handler2 operation.</summary>
        void ProcessSecurity_Api134_Handler2();

        /// <summary>Validates the Security_Api134_Handler2 state.</summary>
        bool ValidateSecurity_Api134_Handler2();
    }

}