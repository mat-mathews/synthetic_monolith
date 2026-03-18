using Admin.Data117;
using Admin.Service456;
using Auth.Client;
using Auth.Models23;
using Billing.Models;
using Common.Web488;
using Export.Client13;
using Export.Shared332;
using Export.Web130;
using Import.Events;
using Import.Processors472;
using Logging.Handlers141;
using Notifications.Data348;
using Portal.Core;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Core;
using Workflow.Events327;
using Workflow.Shared;

namespace Common.Processors
{
    public interface ICommon_Processors_Service8
    {
        /// <summary>Processes the Common_Processors_Service8 operation.</summary>
        void ProcessCommon_Processors_Service8();

        /// <summary>Validates the Common_Processors_Service8 state.</summary>
        bool ValidateCommon_Processors_Service8();
    }

}