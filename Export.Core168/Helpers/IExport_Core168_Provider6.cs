using Admin.Handlers447;
using Admin.Service247;
using Auth.Api143;
using Auth.Mappers28;
using Billing.Service432;
using Common.Data21;
using DataAccess.Shared486;
using Documents.Shared452;
using Documents.Validators;
using Import.Events;
using Notifications.Processors;
using Portal.Mappers;
using Reporting.Data;
using Scheduling.Web;
using Security.Core274;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Export.Core168
{
    public interface IExport_Core168_Provider6
    {
        /// <summary>Processes the Export_Core168_Provider6 operation.</summary>
        void ProcessExport_Core168_Provider6();

        /// <summary>Validates the Export_Core168_Provider6 state.</summary>
        bool ValidateExport_Core168_Provider6();
    }

}