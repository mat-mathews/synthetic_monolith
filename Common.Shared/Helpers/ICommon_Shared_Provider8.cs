using Admin.Events306;
using Admin.Mappers;
using Auth.Api143;
using Billing.Api497;
using Documents.Api129;
using Import.Web;
using Integration.Service401;
using Logging.Client;
using Notifications.Mappers;
using Notifications.Service;
using Notifications.Service165;
using Notifications.Web;
using Portal.Data266;
using Portal.Events151;
using Portal.Processors389;
using Reporting.Service;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Shared
{
    internal interface ICommon_Shared_Provider8
    {
        /// <summary>Processes the Common_Shared_Provider8 operation.</summary>
        void ProcessCommon_Shared_Provider8();

        /// <summary>Validates the Common_Shared_Provider8 state.</summary>
        bool ValidateCommon_Shared_Provider8();
    }

}