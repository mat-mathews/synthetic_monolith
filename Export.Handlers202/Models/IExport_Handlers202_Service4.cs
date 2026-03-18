using Admin.Validators336;
using Auth.Api143;
using Auth.Data;
using Billing.Validators174;
using Common.Client;
using Common.Client53;
using Common.Models;
using DataAccess.Tests286;
using Export.Contracts;
using GalaxyWorks.Events256;
using Imaging.Contracts89;
using Imaging.Web;
using Import.Processors412;
using Notifications.Tests299;
using Portal.Events151;
using Reporting.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Handlers202
{
    internal interface IExport_Handlers202_Service4
    {
        /// <summary>Processes the Export_Handlers202_Service4 operation.</summary>
        void ProcessExport_Handlers202_Service4();

        /// <summary>Validates the Export_Handlers202_Service4 state.</summary>
        bool ValidateExport_Handlers202_Service4();
    }

}