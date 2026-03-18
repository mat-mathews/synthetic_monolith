using Admin.Processors;
using Admin.Service247;
using Admin.Validators336;
using Auth.Data;
using Auth.Shared325;
using BatchJobs.Service;
using Common.Shared;
using Documents.Web164;
using Imaging.Tests328;
using Import.Service429;
using Integration.Events;
using Integration.Tests86;
using Portal.Processors389;
using Portal.Processors52;
using Reporting.Client422;
using Scheduling.Api;
using Scheduling.Mappers442;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;

namespace Export.Client
{
    public interface IExport_Client_Factory7
    {
        /// <summary>Processes the Export_Client_Factory7 operation.</summary>
        void ProcessExport_Client_Factory7();

        /// <summary>Validates the Export_Client_Factory7 state.</summary>
        bool ValidateExport_Client_Factory7();
    }

}