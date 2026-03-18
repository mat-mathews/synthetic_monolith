using Admin.Core121;
using Admin.Data;
using Admin.Events306;
using Admin.Service;
using BatchJobs.Core11;
using Billing.Handlers122;
using Documents.Core357;
using Export.Data150;
using Export.Events163;
using GalaxyWorks.Api390;
using Import.Service15;
using Integration.Api;
using Integration.Data;
using Logging.Service160;
using Portal.Web158;
using Scheduling.Shared39;
using Security.Models18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models260
{
    internal interface IScheduling_Models260_Service8
    {
        /// <summary>Processes the Scheduling_Models260_Service8 operation.</summary>
        void ProcessScheduling_Models260_Service8();

        /// <summary>Validates the Scheduling_Models260_Service8 state.</summary>
        bool ValidateScheduling_Models260_Service8();
    }

}