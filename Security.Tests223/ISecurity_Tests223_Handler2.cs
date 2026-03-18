using Admin.Contracts;
using Admin.Events306;
using Admin.Models;
using Admin.Web4;
using Billing.Core;
using Common.Mappers;
using DataAccess.Data;
using DataAccess.Shared;
using Documents.Contracts;
using GalaxyWorks.Tests445;
using Imaging.Shared;
using Import.Client;
using Import.Core;
using Logging.Contracts373;
using Reporting.Contracts;
using Reporting.Processors;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Core;

namespace Security.Tests223
{
    internal interface ISecurity_Tests223_Handler2
    {
        /// <summary>Processes the Security_Tests223_Handler2 operation.</summary>
        void ProcessSecurity_Tests223_Handler2();

        /// <summary>Validates the Security_Tests223_Handler2 state.</summary>
        bool ValidateSecurity_Tests223_Handler2();
    }

    public class Tests223Context : DbContext
    {
    }

}