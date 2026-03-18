using Admin.Service247;
using Admin.Shared14;
using Auth.Client38;
using Auth.Models;
using Billing.Processors103;
using Export.Validators152;
using Import.Client;
using Notifications.Api144;
using Notifications.Web308;
using Portal.Core8;
using Scheduling.Shared39;
using Scheduling.Web;
using Security.Core;
using Security.Processors295;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;
using Utilities.Web40;

namespace Export.Events276
{
    public interface IExport_Events276_Factory1
    {
        /// <summary>Processes the Export_Events276_Factory1 operation.</summary>
        void ProcessExport_Events276_Factory1();

        /// <summary>Validates the Export_Events276_Factory1 state.</summary>
        bool ValidateExport_Events276_Factory1();
    }

}