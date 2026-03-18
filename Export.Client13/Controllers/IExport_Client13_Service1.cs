using Admin.Core121;
using Admin.Handlers447;
using Admin.Web4;
using Auth.Client271;
using Auth.Mappers208;
using Common.Models;
using DataAccess.Contracts;
using DataAccess.Shared486;
using GalaxyWorks.Client;
using GalaxyWorks.Service293;
using Imaging.Data;
using Imaging.Events416;
using Imaging.Service;
using Integration.Validators;
using Reporting.Events;
using Security.Shared;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;

namespace Export.Client13
{
    public interface IExport_Client13_Service1
    {
        /// <summary>Processes the Export_Client13_Service1 operation.</summary>
        void ProcessExport_Client13_Service1();

        /// <summary>Validates the Export_Client13_Service1 state.</summary>
        bool ValidateExport_Client13_Service1();
    }

}