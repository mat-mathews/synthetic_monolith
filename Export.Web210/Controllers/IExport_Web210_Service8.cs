using Admin.Handlers447;
using Admin.Handlers450;
using Admin.Models;
using Auth.Api116;
using Auth.Contracts395;
using Auth.Handlers467;
using Auth.Processors400;
using BatchJobs.Tests270;
using Common.Contracts279;
using Common.Processors245;
using Common.Validators50;
using DataAccess.Models;
using Documents.Models;
using Export.Data150;
using Export.Service;
using Notifications.Shared396;
using Reporting.Tests67;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Web210
{
    internal interface IExport_Web210_Service8
    {
        /// <summary>Processes the Export_Web210_Service8 operation.</summary>
        void ProcessExport_Web210_Service8();

        /// <summary>Validates the Export_Web210_Service8 state.</summary>
        bool ValidateExport_Web210_Service8();
    }

}