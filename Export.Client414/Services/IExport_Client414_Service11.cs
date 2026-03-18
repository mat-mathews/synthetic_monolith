using Admin.Mappers;
using Auth.Service;
using Common.Api57;
using DataAccess.Client82;
using Documents.Api;
using Export.Events163;
using Export.Processors104;
using Export.Validators;
using Import.Handlers;
using Import.Service265;
using Integration.Shared;
using Notifications.Models277;
using Notifications.Service;
using Reporting.Tests67;
using Scheduling.Api3;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Client414
{
    public interface IExport_Client414_Service11
    {
        /// <summary>Processes the Export_Client414_Service11 operation.</summary>
        void ProcessExport_Client414_Service11();

        /// <summary>Validates the Export_Client414_Service11 state.</summary>
        bool ValidateExport_Client414_Service11();
    }

}