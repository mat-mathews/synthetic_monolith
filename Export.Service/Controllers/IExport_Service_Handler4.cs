using Admin.Api;
using Admin.Handlers61;
using Admin.Models476;
using Common.Web438;
using DataAccess.Api98;
using Export.Events163;
using Export.Mappers237;
using Export.Processors426;
using Export.Processors79;
using Integration.Events301;
using Logging.Tests292;
using Logging.Web;
using Notifications.Core;
using Notifications.Handlers470;
using Notifications.Web;
using Reporting.Handlers;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Service
{
    public interface IExport_Service_Handler4
    {
        /// <summary>Processes the Export_Service_Handler4 operation.</summary>
        void ProcessExport_Service_Handler4();

        /// <summary>Validates the Export_Service_Handler4 state.</summary>
        bool ValidateExport_Service_Handler4();
    }

}