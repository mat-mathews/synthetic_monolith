using Admin.Data;
using Admin.Shared;
using Admin.Validators240;
using Billing.Client22;
using Documents.Core357;
using Documents.Data419;
using Documents.Service215;
using Export.Client;
using Import.Client356;
using Integration.Processors;
using Portal.Service489;
using Portal.Validators250;
using Reporting.Contracts;
using Reporting.Processors;
using Reporting.Shared;
using Reporting.Tests67;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;

namespace Export.Core
{
    internal interface IExport_Core_Handler10
    {
        /// <summary>Processes the Export_Core_Handler10 operation.</summary>
        void ProcessExport_Core_Handler10();

        /// <summary>Validates the Export_Core_Handler10 state.</summary>
        bool ValidateExport_Core_Handler10();
    }

}