using Admin.Shared310;
using Admin.Validators336;
using Auth.Core140;
using Documents.Service215;
using Export.Core;
using GalaxyWorks.Client;
using Integration.Handlers244;
using Integration.Handlers333;
using Integration.Tests86;
using Notifications.Web90;
using Portal.Core;
using Portal.Validators250;
using Scheduling.Core480;
using Scheduling.Models;
using Security.Contracts238;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;

namespace Reporting.Service
{
    public interface IReporting_Service_Factory
    {
        /// <summary>Processes the Reporting_Service_Factory operation.</summary>
        void ProcessReporting_Service_Factory();

        /// <summary>Validates the Reporting_Service_Factory state.</summary>
        bool ValidateReporting_Service_Factory();
    }

}