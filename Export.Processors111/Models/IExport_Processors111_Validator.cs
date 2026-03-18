using Admin.Handlers450;
using Admin.Validators431;
using Admin.Web;
using Auth.Data;
using Auth.Handlers467;
using Common.Api;
using Common.Models381;
using Export.Core372;
using Export.Web229;
using GalaxyWorks.Mappers318;
using Imaging.Tests;
using Import.Api314;
using Notifications.Client257;
using Notifications.Tests195;
using Reporting.Api287;
using Reporting.Handlers347;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Export.Processors111
{
    internal interface IExport_Processors111_Validator
    {
        /// <summary>Processes the Export_Processors111_Validator operation.</summary>
        void ProcessExport_Processors111_Validator();

        /// <summary>Validates the Export_Processors111_Validator state.</summary>
        bool ValidateExport_Processors111_Validator();
    }

}